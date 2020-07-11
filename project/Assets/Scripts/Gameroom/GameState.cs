using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : Singleton<GameState> {

    [SerializeField] private int money = 100;
    [SerializeField] private List<string> transactionHistory = new List<string>();

    public int getMoney() {
        return money;
    }

    public void updateMoney(int change) {
        money += change;
    }

    public void addTransaction(string trans) {
        transactionHistory.Add(trans);
    }
}
