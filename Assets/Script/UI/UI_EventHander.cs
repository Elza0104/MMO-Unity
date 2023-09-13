using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHander : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnClickHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("wddwd");
        if(OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
        
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
        Debug.Log("drag");
    }
}