using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransactionHistory : MonoBehaviour
{

    public GameObject displayText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameState gameState = GameObject.FindObjectOfType<GameState>();

        gameState.addTransaction("32k in cs roulette\n");
        gameState.addTransaction("1000$ in KDA skins\n");
        gameState.addTransaction("20$ subscription on Belle's OnlyFan\n");

        displayText.GetComponent<Text>().text = gameState.getTransactionHistory();
    }
    
}
