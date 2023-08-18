using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager
{
    // public Action<string> PrintAllEvent;

    public Action KeyAction = null;

    public void OnUpdate()
    {
        if (Input.anyKey ==  false)
            return;
        if (KeyAction != null)
            KeyAction.Invoke();
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
