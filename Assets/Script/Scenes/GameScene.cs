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

        Dictionary<int, Data.Stat> dic = Managers.Data.StatDict;
        Data.Stat stat = dic[1];

        gameObject.GetAddComponent<CursorController>();

        GameObject player = Managers.GM.Spawn(Define.WorldObject.Player, "unitychan");
        Camera.main.gameObject.GetAddComponent<CameraController>().SetPlayer(player);
        
        Managers.GM.Spawn(Define.WorldObject.Monster, "Knight");
    }

    public override void Clear()
    {
        
    }
}
