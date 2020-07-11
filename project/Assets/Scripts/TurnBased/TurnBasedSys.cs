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

        // Start is called before the first frame update
        void Start()
        {
            currentState = State.PLAYER;
            player = GameObject.FindObjectOfType<Player>();
            enemy = GameObject.FindObjectOfType<Enemy>();

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
                        else currentState = State.ENEMY;

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
                        else currentState = State.PLAYER;

                        player.resetState();
                        break;

                    case State.WIN:
                        GameObject.Find("MessageBox").GetComponent<Text>().text = "Player survived Rito";
                        yield return new WaitForSeconds(1f);

                        currentState = State.FINISH;
                        LevelManager.instance.loadGameRoom();
                        break;

                    case State.LOSE:
                        int choice = Random.Range(0, loseMessages.Length);
                        string msg = loseMessages[choice];
                        GameObject.Find("MessageBox").GetComponent<Text>().text = msg;
                        yield return new WaitForSeconds(1f);

                        currentState = State.FINISH;
                        GameState.instance.addTransaction(msg);
                        GameState.instance.updateMoney(-20); 
                        LevelManager.instance.loadGameRoom();
                        break;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}