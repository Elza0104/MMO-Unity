using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private int _order = 0;
    private Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    private UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    public void SetCavas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;


        if (sort)
        {
            canvas.sortingOrder = (_order);
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }


    public void ClosePopupUI()
    {
        if(_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resources.Destroy(popup.gameObject);
        Debug.Log(popup.gameObject);

        popup = null;
    }
    
    public void ClosePopupUI(UI_Popup pop)
    {
        if(_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != pop)
        {
            Debug.Log("Close Popup Failed");
            return;
        }

        CloseAllPopupUI();
    }

    void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }
    public T ShowSceneUI<T>(string prefabName = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(prefabName))
            prefabName = typeof(T).Name;

        GameObject go = Managers.Resources.Instantiate($"UI/Inven/{prefabName}");
        T sceneUI = Util.GetAddComponent<T>(go);
        _sceneUI = sceneUI;

        return sceneUI;
    }
    public T ShowPopupUI <T>(string prefabName = null)  where T : UI_Popup
    {
        if (string.IsNullOrEmpty(prefabName))
            prefabName = typeof(T).Name;

        GameObject go = Managers.Resources.Instantiate($"UI/Popup/{prefabName}");
        T popup = Util.GetAddComponent<T>(go);
        
        _popupStack.Push(popup);
        go.transform.SetParent(Root.transform);
        
        return popup;
    }

    public T MakeSubItem<T>(Transform parent = null, string prefabName = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(prefabName))
            prefabName = typeof(T).Name;

        GameObject go = Managers.Resources.Instantiate($"UI/SubItem/{prefabName}");
        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetAddComponent<T>(go);
    }
    public void Clear()
    {
        ClosePopupUI();
        _sceneUI = null;
    }

}
