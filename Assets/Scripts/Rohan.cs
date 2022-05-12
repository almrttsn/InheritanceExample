using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rohan : Men
{
    public override void WelcomeSpeech()
    {
        Debug.Log("Aragon and King Theoden talking");
        _wasGondorThereWhenTheWestfoldFell = false;     //rohan false ediyor bu bool'u sadece men ve
                                                        // rohan biliyor, elf dwarf bilmiyor
    }

}
