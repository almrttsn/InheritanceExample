using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Creature
{
    public override void WelcomeSpeech()
    {
        Debug.Log("Welcome to Eriador");
    }

    public override void MotivationSpeech()
    {
        Debug.Log("Tangado haid! Leithio i philinn!");
    }

    public override void ForwardMarch()
    {
        base.ForwardMarch();
    }
}

