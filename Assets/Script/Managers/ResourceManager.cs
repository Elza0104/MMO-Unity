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

        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        if (index > 0)
        {
            go.name = go.name.Substring(0, index);
        }

        return go;
    }
    public void Destroy(GameObject go, float t = 0.0f)
    {
        if (go == null)
            return;
        Object.Destroy(go, t);
    }
}
