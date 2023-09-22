using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public AudioClip AudioClip;
    public AudioClip AudioClip2;
    private int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        i++;
        
        if(i % 2 == 0)
            Managers.Sound.Play("univ0001", Define.Sound.Bgm);
        else
            Managers.Sound.Play(AudioClip2, Define.Sound.Bgm);
        
    }
}
