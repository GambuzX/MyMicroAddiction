using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletBalanceSlot : MonoBehaviour
{

    public GameObject walletBalance;
    
    // Start is called before the first frame update
    void Start()
    {
        GameState gameState = GameObject.FindObjectOfType<GameState>();
        walletBalance.GetComponent<Text>().text = "$" + gameState.getMoney();
    }

    // Update is called once per frame
    void Update()
    {
        GameState gameState = GameObject.FindObjectOfType<GameState>();
        walletBalance.GetComponent<Text>().text = "$" + gameState.getMoney();
    }
}
