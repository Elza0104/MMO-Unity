using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : BaseController
{
    public float _speed = 5.0f;

    private int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);
    
    private bool _stopSkill = false;
    
    private PlayerStat _playerStat;
    
    void Start()
    {
        WorldObjectType = Define.WorldObject.Player;
        _playerStat = gameObject.GetComponent<PlayerStat>();
        
        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;

        Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

        //Managers.UI.ClosePopupUI(button);
    }

    private void OnHitEvent()
    {
        if (_lockOnTarget != null)
        {
            Stat targetStat = _lockOnTarget.GetComponent<Stat>();
            targetStat.OnAttacked(_playerStat);
        }
        
        
        
        
        if (_stopSkill)
            State = Define.State.Idle;
        else
            State = Define.State.Skill;
    }

    protected override void UpdateMoving()
    {
        if (_lockOnTarget != null)
        {
            _destPos = _lockOnTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance < 1.0f)
            {
                State = Define.State.Skill;
                // _speed = 5f;
                return;
            }   
        }
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
            return;
        }

        Debug.DrawRay(transform.position + Vector3.up * 0.5f, dir.normalized, Color.green);
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, _mask))
        {
            if (Input.GetMouseButton(0) == false)
                State = Define.State.Idle;
            return;
        }
        
        float moveDist = Math.Clamp(_playerStat.MoveSpeed * Time.deltaTime, 0, dir.magnitude);
        transform.position += dir.normalized * moveDist;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 50 * Time.deltaTime);
    }

    protected override void UpdateIdle()
    {
        
    }

    protected override void UpdateDie()
    {
        Debug.Log("Player is dead");
    }

    protected override void UpdateSkill()
    {
        if (_lockOnTarget != null)
        {
            Vector3 dir = _lockOnTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }
    
    void OnMouseEvent(Define.MouseEvent evt)
    {
        if (State == Define.State.Die)
            return;

        switch (State)
        {
            case Define.State.Idle:
                OnMouseEvent_IdleRun(evt);
                break;
            case Define.State.Moving:
                OnMouseEvent_IdleRun(evt);
                break;
            case Define.State.Skill:
            {
                if (evt == Define.MouseEvent.PointerUp)
                    _stopSkill = true;
            }
                break;
        }
    }

    private void OnMouseEvent_IdleRun(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.magenta, 1.0f); //광선 표시

        RaycastHit hit;
        bool raycastHit = Physics.Raycast(ray, out hit, 100, _mask);

        switch (evt)
        {
            case Define.MouseEvent.PointerDown :
                if (raycastHit)
                {
                    _destPos = hit.point;
                    State = Define.State.Moving;
                    _stopSkill = false;

                    if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
                        _lockOnTarget = hit.collider.gameObject;
                    else
                        _lockOnTarget = null;
                }
                break;
            case Define.MouseEvent.Press :
                if (_lockOnTarget == null && raycastHit)
                    _destPos = hit.point;
                break;
            case Define.MouseEvent.PointerUp :
                _stopSkill = true;
                break;
        }
    }
}
