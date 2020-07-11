using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Evasion {
    public class Timer : MonoBehaviour
    {
        [SerializeField] float totalTime = 10f;
        [SerializeField] float timeLeft = 10f;
        [SerializeField] Text text; 

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
        
        private void WinGame() {
            print("won game");
        }

        private void updateUI() {
            text.text = "" + Mathf.RoundToInt(timeLeft);
            if(timeLeft < totalTime/5) {
                text.color = Color.red;
            }
        }
    }
}