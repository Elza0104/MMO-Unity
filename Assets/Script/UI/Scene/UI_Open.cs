using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Open : MonoBehaviour
{
    private bool isInven;
    public GameObject Inven;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InvenOnOff()
    {
        if (!isInven)
        {
            Inven.SetActive(true);
            isInven = true;
        }
        if (isInven)
        {
            Inven.SetActive(false);
            isInven = false;
        }
    }
}
