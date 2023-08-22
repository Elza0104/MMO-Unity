using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

public class ResourceManager 
{
    public T Load<T>(string path) where T : Object
    {
        Debug.Log(Resources.Load<T>(path));
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab =  Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failled to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);
    }
}
