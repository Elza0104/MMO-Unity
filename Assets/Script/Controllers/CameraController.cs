using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.CameraMode _mode = Define.CameraMode.QueterView;
    [SerializeField] private Vector3 _delta;
    [SerializeField] private GameObject _player;
    // [SerializeField] private GameObject _playersHead;
    public void SetPlayer(GameObject player)
    {
        _player = player;
    }

    private void LateUpdate()
    {
        // Debug.Log(_playersHead.transform.position + "H");
        // Debug.Log(_player.transform.position);
        if (_mode == Define.CameraMode.QueterView)
        {
            if (_player.isValid() == false)
            {
                return;
            }
            RaycastHit hit;
            Debug.DrawRay(transform.position,   Vector3.forward, Color.magenta, 1.0f);
            if (Physics.Raycast(_player.transform.position, _delta, out hit,
                    _delta.magnitude, LayerMask.GetMask("Ground")))
            {
                    
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }
        
        
        
    }
}
