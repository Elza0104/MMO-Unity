using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5.0f;
    private float _yAngle = 0.0f;

    private PlayerStat _playerStat;
    
    public Vector3 _destPos;

    
    private int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);
    
    void Start()
    {
        
        
        _playerStat = gameObject.GetComponent<PlayerStat>();
        
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
        
        

        //Managers.UI.ClosePopupUI(button);
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

        float moveDist = Math.Clamp(_playerStat.MoveSpeed * Time.deltaTime, 0, dir.magnitude);

        NavMeshAgent nma = gameObject.GetAddComponent<NavMeshAgent>();
        nma.Move(dir.normalized * moveDist);
        
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, dir.normalized, Color.green);
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, LayerMask.GetMask("Block")))
        {
            _state = PlayerState.Idle;
            return;
        }
        if (dir.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 
                30 * Time.deltaTime);
        }
        
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _playerStat.MoveSpeed);
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

        LayerMask mask = LayerMask.GetMask("Groud"); //감지 안되게 가리기
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, _mask))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;

            if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {
                Debug.Log("Monster Clicked");
            }
            else
            {
                Debug.Log("Ground Clicked");
            }
        }
    }
}
