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
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resources.Destroy(child.gameObject);

        for (int i = 0; i < 30; i++)
        {
            GameObject item = Managers.Resources.Instantiate($"UI/Inven/Item");
            item.transform.SetParent(gridPanel.transform);

            UI_Inven_Item invenItem = Util.GetAddComponent<UI_Inven_Item>(item);
            invenItem.SetInfo($"조희원{i}");
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
    