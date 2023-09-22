using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    

    public override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();

        for (int i = 0; i < 2; i++)
        {
            Managers.Resources.Instantiate("unitychan");
        }
    }

    public override void Clear()
    {
        
    }
}
