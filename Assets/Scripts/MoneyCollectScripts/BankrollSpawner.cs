using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankrollSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bankrolls;
    private int _bankrollCount;
    private int Wallet;    

    private void Update()
    {
        _bankrollCount = Wallet / 20;
        SpawnBankroll();
        Wallet++;
    }

    private void SpawnBankroll()
    {
        for (int i = 0; i < _bankrollCount; i++)
        {
            {
                _bankrolls[i].SetActive(true);
            }
        }
    }

}
