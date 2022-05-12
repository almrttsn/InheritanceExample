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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Wallet += 100;
        }
        _bankrollCount = Wallet / 20;
        SpawnBankroll();
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

    private IEnumerator SpawnDelayer()
    {
        yield return new WaitForSeconds(1f);
    }

}
