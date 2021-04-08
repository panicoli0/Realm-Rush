using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 50;

    public bool CreateTower(Tower towerPrefab, Vector3 pos)
    {

        CurrencySystem bank = FindObjectOfType<CurrencySystem>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= towerCost)
        {
            Instantiate(towerPrefab, pos, Quaternion.identity);
            bank.Withdraw(towerCost);
            return true;
        }
        else
        {
            Debug.Log("Not enought Money");
        }

        return false;

    }

}
