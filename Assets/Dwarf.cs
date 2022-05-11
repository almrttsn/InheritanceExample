using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Creature               //creature'den inherit
{
    public override void MotivationSpeech() //dwarf abstract motivasyonu
    {
        Debug.Log("Dwarves: Baruk Khazâd! To Battle!");
    }
}
