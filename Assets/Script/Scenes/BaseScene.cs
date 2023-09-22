using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public abstract class BaseScene : MonoBehaviour
{
    //private Define.Scene _sceneType = Define.Scene.Unknown;
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;

    public void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            Managers.Resources.Instantiate("UI/EventSystem").name = "@EventSystem";
    }

    public abstract void Clear();
}
