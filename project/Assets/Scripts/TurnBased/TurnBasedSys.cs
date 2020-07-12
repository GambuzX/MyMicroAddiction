using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBased {
    public class TurnBasedSys : MonoBehaviour
    {
        [SerializeField] private State currentState;
        private Player player;
        private Enemy enemy;

        [SerializeField] private string[] loseMessages;

        private Text turnText;

        // Start is called before the first frame update
        void Start()
        {
            currentState = State.PLAYER;
            player = GameObject.FindObjectOfType<Player>();
            enemy = GameObject.FindObjectOfType<Enemy>();

            turnText = GameObject.Find("Turn").GetComponent<Text>();

            StartCoroutine("updateStateMachine");
        }

        IEnumerator updateStateMachine() {
            Action action = null;
            while(currentState != State.FINISH) {

                switch(currentState) {
                    case State.PLAYER:
                        action = player.getChosenAction();
                        if (action == null) break;

                        action.executeAnimation();
                        yield return new WaitForSeconds(1f);
                        action.execute(); // maybe wait for animations?
                        yield return new WaitForSeconds(1f);

                        if (player.dead()) currentState = State.LOSE;
                        else if (enemy.dead()) currentState = State.WIN;
                        else {
                            currentState = State.ENEMY;
                            turnText.text = "Rito Turn";
                        }

                        enemy.resetState();
                        break;

                    case State.ENEMY:
                        action = enemy.chooseAction();

                        action.executeAnimation();
                        yield return new WaitForSeconds(1f);
                        action.execute();
                        yield return new WaitForSeconds(1f);

                        if (player.dead()) currentState = State.LOSE;
                        else if (enemy.dead()) currentState = State.WIN;
                        else {
                            currentState = State.PLAYER;
                            turnText.text = "Player Turn";
                        }

                        player.resetState();
                        break;

                    case State.WIN:
                        Text msgBox = GameObject.Find("MessageBox").GetComponent<Text>();
                        msgBox.text = "Player survived Rito";
                        msgBox.color = Color.green;
                        yield return new WaitForSeconds(3f);

                        currentState = State.FINISH;
                        GameState.instance.addTransaction("Evaded Lig'a'Legends skin store", Minigame.TURN_BASED);
                        LevelManager.instance.loadGameRoom();
                        break;

                    case State.LOSE:
                        string msg = loseMessages[Random.Range(0, loseMessages.Length)];
                        Text mesgBox = GameObject.Find("MessageBox").GetComponent<Text>();
                        mesgBox.text = msg;
                        mesgBox.color = Color.red;
                        yield return new WaitForSeconds(3f);

                        currentState = State.FINISH;
                        GameState.instance.addTransaction(msg, Minigame.TURN_BASED);
                        GameState.instance.updateMoney(-20); 
                        LevelManager.instance.loadGameRoom();
                        break;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}