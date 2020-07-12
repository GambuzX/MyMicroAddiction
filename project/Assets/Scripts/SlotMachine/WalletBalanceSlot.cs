using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletBalanceSlot : MonoBehaviour
{

    public GameObject walletBalance;

    private Text balanceText;
    
    // Start is called before the first frame update
    void Start()
    {
        balanceText = walletBalance.GetComponent<Text>();
        balanceText.text = "$" + GameState.instance.getMoney();
    }

    // Update is called once per frame
    void Update()
    {
        balanceText.text = "$" + GameState.instance.getMoney();
    }
}
