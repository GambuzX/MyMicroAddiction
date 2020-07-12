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

        displayText.GetComponent<Text>().text = gameState.getTransactionHistory();
    }
    
}
