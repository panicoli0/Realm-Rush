using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int rewardGold;
    [SerializeField] int penaltyGold;
    CurrencySystem bank;

    void Start()
    {
        bank = FindObjectOfType<CurrencySystem>();
        rewardGold = 25;
        penaltyGold = 25;
    }

    public void RewardGold()
    {
        if (bank == null)
        {
            return;
        }
        bank.Deposit(rewardGold);
    }

    public void PenaltyGold()
    {
        if (bank == null)
        {
            return;
        }
        bank.Withdraw(penaltyGold);
    }

}
