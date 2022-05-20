using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giraffe : MonoBehaviour
{
    private bool _isVeysi = true;
    private bool _isGoodMan = true;

    private void Start()
    {
        VeysiOrNot();
    }

    private void VeysiOrNot()
    {
        if(_isVeysi && _isGoodMan)
        {
            Debug.Log("You're perfect blend");
        }
        else if(_isVeysi && !_isGoodMan)
        {
            Debug.Log("You're Veysi but is not good man");
        }
        else if(!_isVeysi && _isGoodMan)
        {
            Debug.Log("You're good man but not a Veysi");
        }
        else
        {
            Debug.Log("Shame on you!");
        }
    }
}
