using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvasionTimer : Timer
{
    void Start() {
        timeLeft = totalTime;
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(timeLeft, 0);

        updateUI();

        if (timeLeft <= 0) {
            WinGame();
        }
    }
    
    public override void WinGame() {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        GameState gameState = GameObject.FindObjectOfType<GameState>();

        levelManager.loadGameRoom();
    }

    private void updateUI() {
        text.text = "" + Mathf.RoundToInt(timeLeft);
        if(timeLeft < totalTime/5) {
            text.color = Color.red;
        }
    }
}