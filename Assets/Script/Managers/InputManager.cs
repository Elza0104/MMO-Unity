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

    public void OnUpdate()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.press);
                _pressed = true;
                
            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.click);
                _pressed = false;
                
                
            }
        }
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
