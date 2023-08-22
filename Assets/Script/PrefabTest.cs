using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    
    GameObject prefab;

    private GameObject tank;
    void Start()
    {
        tank = Managers.Resources.Instantiate("Prefab/tank.prefab");
        
        // Managers.Resources.Destroy(tank, 3.0f);
    }

    void Update()
    {
        
    }
}
