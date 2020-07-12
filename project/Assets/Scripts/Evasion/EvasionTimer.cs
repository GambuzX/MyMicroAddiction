using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvasionTimer : Timer
{    
    private string[] sales = {
        "Summer",
        "Winter",
        "Spring",
        "Halloween",
        "Christmas"
    };

    public override void WinGame() {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        GameState gameState = GameObject.FindObjectOfType<GameState>();

        GameState.instance.addTransaction("Survived Steam " + sales[Random.Range(0, sales.Length)] + " sales", Minigame.EVASION);
        levelManager.loadGameRoom();
    }
}