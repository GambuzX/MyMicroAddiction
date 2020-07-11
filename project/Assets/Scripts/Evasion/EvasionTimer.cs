using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvasionTimer : Timer
{    
    public override void WinGame() {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        GameState gameState = GameObject.FindObjectOfType<GameState>();

        levelManager.loadGameRoom();
    }
}