using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedSys : MonoBehaviour
{
    [SerializeField] private State currentState;
    private Player player;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.PLAYER;
        player = GameObject.FindObjectOfType<Player>();
        enemy = GameObject.FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        Action action = null;
        switch(currentState) {
            case State.PLAYER:
                action = player.getChosenAction();
                if (action == null) break;

                action.execute(); // maybe wait for animations?

                if (player.dead()) currentState = State.LOSE;
                else if (enemy.dead()) currentState = State.WIN;
                else currentState = State.ENEMY;

                break;

            case State.ENEMY:
                action = enemy.chooseAction();
                action.execute();

                if (player.dead()) currentState = State.LOSE;
                else if (enemy.dead()) currentState = State.WIN;
                else currentState = State.PLAYER;

                player.resetAction();
                break;
            case State.WIN:
                // trigger win
                break;

            case State.LOSE:
                // trigger gg wp
                break;
        }
    }
}
