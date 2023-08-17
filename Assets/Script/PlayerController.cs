using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 1.0f;
    private float _yAngle = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        _yAngle += Time.deltaTime * _speed;
        // transform.eulerAngles = new Vector3(0.0f, -_yAngle, 0.0f);
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.Translate (Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.Translate (Vector3.right * Time.deltaTime * _speed);
        }
    }
}
