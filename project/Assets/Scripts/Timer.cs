using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Timer : MonoBehaviour
{
    [SerializeField] protected float totalTime = 10f;
    [SerializeField] protected float timeLeft = 10f;
    [SerializeField] protected Text text; 

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
    
    public abstract void WinGame();

    private void updateUI() {
        text.text = "" + Mathf.RoundToInt(timeLeft);
        if(timeLeft < totalTime/5) {
            text.color = Color.red;
        }
    }
}