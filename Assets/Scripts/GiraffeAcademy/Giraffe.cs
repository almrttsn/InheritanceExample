using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giraffe : MonoBehaviour
{
    [SerializeField] private int num1;
    [SerializeField] private int num2;
    [SerializeField] private string op;
    [SerializeField] private int _enterANumberFrom1To10;

    private bool _isDog = true;
    private bool _isGoodBoy = true;
    float calculationResult;



    private void Start()
    {
        DogOrCat();
        Debug.Log(GetMax(num1, num2));
        Calculator();
        WhileExample();
        DoWhileExample();
        GuessWhichNumberITake();
    }

    private void DogOrCat()         //if else example for two variables
    {
        if (_isDog && _isGoodBoy)
        {
            Debug.Log("You're perfect blend");
        }
        else if (_isDog && !_isGoodBoy)
        {
            Debug.Log("Watch your step!");
        }
        else if (!_isDog && _isGoodBoy)
        {
            Debug.Log("Purring all the time");
        }
        else
        {
            Debug.Log("You little fidget");
        }
    }

    private int GetMax(int num1, int num2)  //find to which number is greater from the other
    {
        int result;
        if (num1 > num2)
        {
            result = num1;
        }
        else
        {
            result = num2;
        }
        return result;
    }

    private void Calculator()   //making calculations
    {
        if (op == "+")
        {
            calculationResult = num1 + num2;
        }
        else if (op == "-")
        {
            calculationResult = num1 - num2;
        }
        Debug.Log(calculationResult);
    }

    private void WhileExample() //trying to write 1,2,3,4 to console
    {
        int index = 1;
        while (index < 5)
        {
            Debug.Log("While example " + index);
            index++;
        }
    }

    private void DoWhileExample()   //trying to write 5,6 to console
    {
        int index = 5;
        do
        {
            Debug.Log("DoWhileExapmle " + index);
            index++;
        }
        while (index < 7);
    }

    private void GuessWhichNumberITake()
    {
        int _myNumber = 7;
        int _guessCount = 0;
        int _guessCountLimit = 3;
        int _guessChanceYouHave = _guessCountLimit - _guessCount;

        while (_guessCount < _guessCountLimit)
        {
            if (_enterANumberFrom1To10 == _myNumber)
            {
                Debug.Log("You Win!");
            }
            else
            {
                _guessCount++;
                Debug.Log("Wrong answer, you have left " + _guessChanceYouHave + " guess chance");
            }

        }

    }

}
