using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankrollSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _visualMoneyObjects;

    private int _realMoneyAmount;
    private int _visualMoneyCountTarget;

    private int _index;

    private void Start()
    {
        for (int i = 0; i < _visualMoneyObjects.Count; i++)
        {
            _visualMoneyObjects[i].SetActive(false);
        }

        StartCoroutine(AddToVisualMoneyStack());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddMoney(100);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeAllMoney();
        }
    }

    private void AddMoney(int moneyAmount)
    {
        _realMoneyAmount += moneyAmount;
        _visualMoneyCountTarget += moneyAmount / 20;
    }

    private IEnumerator AddToVisualMoneyStack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            if (_visualMoneyCountTarget > 0)
            {
                _visualMoneyObjects[_index].SetActive(true);
                _index++;
                _visualMoneyCountTarget--;
            }
        }
    }

    public int TakeAllMoney()
    {
        for (int i = 0; i < _visualMoneyObjects.Count; i++)
        {
            _visualMoneyObjects[i].SetActive(false);
        }
        _visualMoneyCountTarget = 0;
        _index = 0;
        var moneyToSend = _realMoneyAmount;
        _realMoneyAmount = 0;
        return moneyToSend;
    }


}
