using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5.0f;
    private float _yAngle = 0.0f;
    
    public Vector3 _destPos;
    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle
    }

    private PlayerState _state = PlayerState.Idle;
    void Update()
    {
        _yAngle += Time.deltaTime * _speed;
        // transform.eulerAngles = new Vector3(0.0f, -_yAngle, 0.0f);

        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

        // if (_moveToDest)
        // {
        //     Vector3 dir = _destPos - transform.position;
        //     
        // }

        
    }

    private void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }

    private void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.01f)
        {
            _state = PlayerState.Idle;
            // _speed = 5f;
            return;
        }
        // if (dir.magnitude < 0.1f)
        // {
        //     _speed = /*Mathf.Lerp(_speed, 0.5f, 0.2f)*/ 1f;
        // }
        
        float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
        transform.position += dir.normalized * moveDist;
        
        if (dir.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 
                30 * Time.deltaTime);
        }
        
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _speed);
    }

    private void UpdateDie()
    {
        Debug.Log("Player is dead");
    }

    void OnMouseClicked(Define.MouseEvent obj)
    {
        if (_state == PlayerState.Die)
            return;
        // Debug.Log("OnMouseClicked");
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.magenta, 1.0f); //광선 표시

        LayerMask mask = LayerMask.GetMask("Wall"); //감지 안되게 가리기
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
        }
    }
}
