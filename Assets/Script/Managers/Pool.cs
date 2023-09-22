using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public GameObject Original { get; private set; }
    public Transform Root { get; set; }

    private Stack<Poolable> _poolStack = new Stack<Poolable>();

    public void Init(GameObject original, int count = 5)
    {
        Original = original;
        Root = new GameObject().transform;
        Root.name = $"{original.name}_Root";

        for (int i = 0; i < count; i++)
        {
            Push(Create());
        }
    }

    Poolable Create()
    {
        GameObject go = Object.Instantiate<GameObject>(Original);
        go.name = Original.name;
        return go.GetAddComponent<Poolable>();
    }

    public void Push(Poolable poolable)
    {
        if (poolable == null)
            return;

        poolable.transform.parent = Root;
        poolable.gameObject.SetActive(false);
        poolable.isUsing = false;
            
        _poolStack.Push(poolable);
    }

    public Poolable Pop(Transform parent)
    {
        Poolable poolable;

        if (_poolStack.Count > 0)
            poolable = _poolStack.Pop();
        else
            poolable = Create();
            
        poolable.gameObject.SetActive(true);
        
        //DontDestroyOnLoad 해제 용도
        if (parent == null)
            poolable.transform.parent = Managers.Scene.CurrentScene.transform;
        
        poolable.transform.parent = parent;
        poolable.isUsing = true;

        return poolable;
    }
}