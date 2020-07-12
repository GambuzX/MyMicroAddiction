using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transaction {
    public string description;
    public Minigame minigame;

    public Transaction(string d, Minigame m) {
        description = d;
        minigame = m;
    }
}

public class GameState : Singleton<GameState> {

    [SerializeField] private int money = 100;
    private List<Transaction> transactionHistory = new List<Transaction>();

    public int getMoney() {
        return money;
    }

    public void updateMoney(int change) {
        money += change;
    }

    public void resetState()
    {
        money = 100;
        transactionHistory = new List<Transaction>();
    }

    public void addTransaction(string trans, Minigame m) {
        transactionHistory.Add(new Transaction(trans, m));
    }

    public string getTransactionHistory()
    {
        string displayText = "";
        
        foreach (var trans in transactionHistory)
        {
            displayText += trans.description + "\n";
        }

        return displayText;
    }
}
