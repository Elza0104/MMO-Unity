using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        GameObject GridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in GridPanel.transform)
            Managers.Resources.Destroy(child.gameObject);

        for (int i = 0; i < 8; i++)
        {
            GameObject item = Managers.Resources.Instantiate("UI/Inven/UI_Inven.prefab");
            item.transform.SetParent(GridPanel.transform);
        }
    }
    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }
}
