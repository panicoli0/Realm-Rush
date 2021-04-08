using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI goldBalanceText;

    void Awake()
    {
        currentBalance = startingBalance;
    }

    void Update()
    {
        goldBalanceText.text = "Gold: " + currentBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0)
        {
            //lose game cond
            Debug.Log("Your balance is: " + currentBalance + " you lose the game");
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
