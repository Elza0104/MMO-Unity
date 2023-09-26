using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    public override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;
    }

    public override void Clear()
    {
        Debug.Log("로그인");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }
}
