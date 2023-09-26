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
    private ResourceManager _resources = new ResourceManager();
    public UIManager _ui = new UIManager();
    private SceneManagerEX _scene = new SceneManagerEX();
    private SoundManager _sound = new SoundManager();
    private PoolManager _pool = new PoolManager();
    private DataManager _data = new DataManager();
    
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resources { get { return Instance._resources; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static SceneManagerEX Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static DataManager Data { get { return Instance._data; } }
    

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
            s_Instance._sound.Init();
            s_Instance._pool.Init();
            s_Instance._data.Init();
        }
    }

    public static void Clear()
    {
        Sound.Clear();
        UI.Clear();
        Input.Clear();
        Scene.Clear();
        
        Pool.Clear();
    }
}
