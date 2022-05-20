using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giraffe : MonoBehaviour
{
    [SerializeField] private int num1;
    [SerializeField] private int num2;
    [SerializeField] private string op;

    private bool _isVeysi = true;
    private bool _isGoodMan = true;
    float calculationResult;



    private void Start()
    {
        VeysiOrNot();
        Debug.Log(GetMax(num1, num2));
        Calculator();
        Debug.Log(calculationResult);
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

    private int GetMax(int num1, int num2)
    {
        int result;
        if(num1 > num2)
        {
            result = num1;
        }
        else
        {
            result = num2;
        }
        return result;
    }

    private void Calculator()
    {
        if(op == "+")
        {
            calculationResult = num1 + num2;
        }
        else if(op == "-")
        {
            calculationResult = num1 - num2;
        }
    }
    
}
