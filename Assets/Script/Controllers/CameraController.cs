using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.CameraMode _mode = Define.CameraMode.QueterView;
    [SerializeField] private Vector3 _delta;
    [SerializeField] private GameObject _player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = _player.transform.position + _delta;
    }
}
