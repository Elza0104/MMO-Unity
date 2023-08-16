using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers Instance;

    public static Managers GetInstance()
    {
        Init();
        return Instance;
    }

    private void Start()
    {
        
    }

    static void Init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("m");
            if (go == null)
            {
                go = new GameObject() { name = "m" };
                go.AddComponent<Managers>();
            }
        }
    }
}
