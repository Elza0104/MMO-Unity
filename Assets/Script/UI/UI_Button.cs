using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

public class UI_Button : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, Object[]>();
    [SerializeField] private TextMeshProUGUI _text;
    private int _score;

    public void OnButtonClicked()
    {
        _score++;
        _text.text = $"점수 - {_score}";
    }

    private void Start()
    {
        // Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        
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
    void Bind<T>(Type type)
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);
        for (int i = 0; i < names.Length; i++)
        {
            objects[i] = FindChlid<T>(gameObject, names[i]);
        }
    }

    private Object FindChlid<T>(GameObject go, string str = null, bool recursive = false)
    {
        throw new NotImplementedException();
    }
}
