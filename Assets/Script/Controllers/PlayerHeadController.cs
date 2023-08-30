using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private float y = 1.4f;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + y, _player.transform.position.z);
    }
}
