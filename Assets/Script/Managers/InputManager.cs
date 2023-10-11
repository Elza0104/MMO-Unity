using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class InputManager
{
    // public Action<string> PrintAllEvent;

    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    public bool _pressed = false;
    private float _pressedTime = 0f;

    public void OnUpdate()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (!_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.PointerDown);
                    _pressed = true;
                }

                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressedTime = Time.time;
            }
            else
            {
                if (_pressed)
                {
                    if (Time.time - _pressedTime < 0.2f)
                        MouseAction.Invoke(Define.MouseEvent.Click);
                    MouseAction.Invoke(Define.MouseEvent.PointerUp);
                }
                _pressed = false;
                _pressedTime = 0;
            }
            
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null; 
    }



    // void Start()
    // {
    //     PrintAllEvent += PrintA;
    //     PrintAllEvent += PrintB;
    //     
    //     PrintAllEvent.Invoke("Print out!");
    // }
    //
    // void Update()
    // {
    //     
    // }
    //
    // private void PrintA(string obj)
    // {
    //     Debug.Log("A is" + obj);
    // }
    //
    // private void PrintB(string obj)
    // {
    //     Debug.Log("B is" + obj);
    // }
}
