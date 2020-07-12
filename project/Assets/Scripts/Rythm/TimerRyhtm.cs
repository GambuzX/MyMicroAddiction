using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRyhtm : MonoBehaviour
{
    private Image timerBar;
    public float maxTimer = 10f;
    private float timeLeft;
    private int start = 0;
    public GameObject timesUpText;
    public GameObject key;
    public GameObject keyImage;
    public GameObject failCounterText;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiter());
    }

    private IEnumerator Waiter()
    {
        timesUpText.SetActive(false);
        timerBar = GetComponent<Image>();
        yield return new WaitForSecondsRealtime(4);
        start = 1;
        timeLeft = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == 1)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTimer;
            }
            else
            {
                timesUpText.SetActive(true);
                StartCoroutine(EndGame());
            }
        }
    }

    private IEnumerator EndGame()
    {
        key.GetComponent<Text>().text = "";
        keyImage.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        GameState gameState = GameObject.FindObjectOfType<GameState>();
        
        int failCounterNumber = Int32.Parse(failCounterText.GetComponent<Text>().text);
        
        if (failCounterNumber > 0 && failCounterNumber < 3)
        {
            gameState.addTransaction("Bought 30 days subscription to Belle's OnlyFan", Minigame.RYTHM);
        }
        else if (failCounterNumber == 3)
        {
            gameState.addTransaction("Acquired 10 Gamer Girl Bath Water bottles", Minigame.RYTHM);
        }
        else if (failCounterNumber >= 4)
        {
            gameState.addTransaction("Donated $$$ to Belle for her smile", Minigame.RYTHM);
        }
        
        print(gameState.getTransactionHistory());
        
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.loadGameRoom();
    }
}