using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRyhtm : MonoBehaviour
{
    private Image timerBar;
    public float maxTimer = 100f;
    private float timeLeft;
    private int start = 0;
    public GameObject timesUpText;


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
        yield return new WaitForSecondsRealtime(1);
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.loadGameRoom();
    }
}