using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension 
{
    public static void BindUIEvent(this GameObject go, Action<PointerEventData> action,
        Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.AddUIEvent(go, action, type);
    }

    public static T GetAddComponent<T>(this GameObject go) where T : Component
    {
        return Util.GetAddComponent<T>(go);
    }
}
