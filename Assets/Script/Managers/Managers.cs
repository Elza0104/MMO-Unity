using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_Instance;

    public static Managers Instance
    {
        get
        {
            Init();
            return s_Instance;
        }
    }

    private InputManager _input = new InputManager();
    public static InputManager Input
    {
        get { return Instance._input; }
    }
    private ResourceManager _resources = new ResourceManager();
    public static ResourceManager Resources
    {
        get { return Instance._resources; }
    }

    private void Update()
    {
        _input.OnUpdate();
    }

    private void Start()
    {
        
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("m");
            if (go == null)
            {
                go = new GameObject() { name = "m" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }
    }
}
