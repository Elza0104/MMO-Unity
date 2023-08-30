using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5.0f;
    private float _yAngle = 0.0f;
    
    public Vector3 _destPos;
    private bool _moveToDest;

    private float wait_run_ratio = 0;
    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    void Update()
    {
        _yAngle += Time.deltaTime * _speed;
        // transform.eulerAngles = new Vector3(0.0f, -_yAngle, 0.0f);

        if (_moveToDest)
        {
            Vector3 dir = _destPos - transform.position;
            if (dir.magnitude < 0.000000001f)
            {
                
                _moveToDest = false;
                Debug.Log(_moveToDest);
            }
            else
            {
                float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDist;
                if (dir.magnitude > 0.01f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 
                    30 * Time.deltaTime);
                
            }
        }

        if (_moveToDest)
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 12 * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("Wait_Run_Ratio", wait_run_ratio);
            
            anim.Play("Wait_Run");
        }
        else
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 3 * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("Wait_Run_Ratio", wait_run_ratio);
            anim.Play("Wait_Run");
        }
    }

    void OnMouseClicked(Define.MouseEvent obj)
    {
        if (obj != Define.MouseEvent.click)
            return;
        // Debug.Log("OnMouseClicked");
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.magenta, 1.0f); //광선 표시

        LayerMask mask = LayerMask.GetMask("Wall"); //감지 안되게 가리기
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            _destPos = hit.point;
            _moveToDest = true;
            Debug.Log(_moveToDest);
        }
    }
}
