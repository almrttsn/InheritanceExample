using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public int _speedOfRace; //dışarıdan her ırk için ayrı ayrı verilecek değer

    public void Start()
    {
        WelcomeSpeech();    //virtual türündeki fonksiyonum 1 kere çalışsın
        MotivationSpeech(); //abstract türündeki fonksiyonum 1 kere çalışsın
    }

    public void Update()
    {
        ForwardMarch();     //virtual türündeki fonksiyonum sürekli çalışsın yürütsün
    }

    public virtual void WelcomeSpeech()
    {
        Debug.Log("Creature: Welcome to the Middle Earth");
    }
    public abstract void MotivationSpeech();

    public virtual void ForwardMarch()
    {
        transform.position += transform.forward * Time.deltaTime * _speedOfRace;
    }
}
