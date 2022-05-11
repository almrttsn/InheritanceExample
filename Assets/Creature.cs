using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public int _speedOfRace;

    public void Start()
    {
        WelcomeSpeech();    //virtual türündeki fonksiyonum
        MotivationSpeech(); //abstract türündeki fonksiyonum
    }

    public void Update()
    {
        ForwardMarch();     //virtual türündeki fonksiyonum
    }

    public virtual void WelcomeSpeech()
    {
        Debug.Log("Welcome to the Middle Earth");
    }
    public abstract void MotivationSpeech();

    public virtual void ForwardMarch()
    {
        transform.position += transform.forward * Time.deltaTime * _speedOfRace;
    }
}
