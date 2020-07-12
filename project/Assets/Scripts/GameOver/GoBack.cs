using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToRoom()
    {
        GameState gameState = GameObject.FindObjectOfType<GameState>();
        gameState.restartMoney();
        SceneManager.LoadScene("MainMenu");
    }
    
}
