using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Managers.UI.ShowSceneUI<UI_Inven>();
    }
}
