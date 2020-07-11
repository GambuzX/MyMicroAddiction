using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletManager : MonoBehaviour
{
    private GameState state;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.instance;
        text = GameObject.Find("MoneyText").GetComponent<Text>();

        text.text = "$" + state.getMoney();

        if (state.getMoney() <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        LevelManager.instance.gameOver();
    }
}
