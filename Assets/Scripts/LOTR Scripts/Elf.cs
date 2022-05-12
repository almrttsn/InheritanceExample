using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Creature                     //creature'den inherit
{
    public override void WelcomeSpeech()        //elfler farklı welcome desinler
    {
        //Debug.Log("Elves: Welcome to Eriador");
    }

    public override void MotivationSpeech()     //elf abstract motivasyonu
    {
        //Debug.Log("Elves: Tangado haid! Leithio i philinn!");
    }

    public override void ForwardMarch()         //base virtual march'ı
    {                                           //(yazmasam da olurdu gör diye yazdım)
        base.ForwardMarch();
    }
}

