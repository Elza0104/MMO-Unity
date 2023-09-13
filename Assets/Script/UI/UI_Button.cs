using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    private int _score;

    public void OnButtonClicked(PointerEventData obj)
    {
        Debug.Log("aaaaaaaaaaaaaa");
        _score++;
        GetText((int)Texts.Score_Text).text = $"점수{_score}";
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        

        GameObject go = GetImage((int)Images.Image).gameObject;

        AddUIEvent(go, (PointerEventData data) =>
        {
            go.transform.position = data.position;
        }, Define.UIEvent.Drag);
        
        GetButton((int)Buttons.Button).gameObject.AddUIEvent(OnButtonClicked);
    }

    

    enum Buttons
    {
        Button
    }

    enum Texts
    {
        B_Text,
        Score_Text
    }

    enum GameObjects
    {
        Test_Object,
    }

    enum Images
    {
        Image
    }
}
