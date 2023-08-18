using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    
    void Start()
    {
        // GameObject prefab = Resources.Load<GameObject>("Assets/Resources/Prefab/tank.prefab");
        // GameObject tank = Instantiate(prefab);
        GameObject tank = Managers.Resources.Instantiate("tank");
        
        Destroy(tank, 3.0f);
    }

    void Update()
    {
        
    }
}
