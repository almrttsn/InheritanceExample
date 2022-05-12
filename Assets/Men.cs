using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Men : Creature                 //creature'den inherit
{
    protected bool _wasGondorThereWhenTheWestfoldFell;  //Men görsün bunu sadece istiyoruz

    public override void WelcomeSpeech()    //men base welcome kullansın (yazmasam da olurdu)
    {
        base.WelcomeSpeech();
    }
    public override void MotivationSpeech() //men abstract motivasyonu
    {
        Debug.Log("Men: Sons of Gondor, Sons of Rohan, Hold your ground!");
    }

}
