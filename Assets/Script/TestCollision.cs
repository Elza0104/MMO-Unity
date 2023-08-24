using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("TestCollision : " + gameObject.name);
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            // Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            //     Camera.main.nearClipPlane));
            // Vector3 dir = mousePos - Camera.main.transform.position;
            // dir = dir.normalized;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.magenta, 1.0f);

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Debug.Log($"Racast Camera @{hit.collider.gameObject.name}");
            }
        }



        //Debug.Log(Input.mousePosition);
        /*Vector3 look = transform.TransformDirection(Vector3.forward);
        
        Debug.DrawRay(transform.position + Vector3.up, look * 20f, Color.magenta);
        
        RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up, look, 20);
        
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Raycast.. {hit.collider.gameObject.name}");
        }
        
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 3f))
        {
            Debug.Log(($"Raycast!{hit.collider.gameObject.name}"));
        }
        */
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}
