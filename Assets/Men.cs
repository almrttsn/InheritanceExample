using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Men : Creature
{
    public override void MotivationSpeech()
    {
        Debug.Log("Sons of Gondor, Sons of Rohan, Hold your ground!");
    }

    public override void WelcomeSpeech()
    {
        base.WelcomeSpeech();
    }
}
