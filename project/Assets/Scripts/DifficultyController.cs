using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Evasion;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] private Minigame minigame;

    // Start is called before the first frame update
    void Start()
    {
        setLevelDifficulty();
    }

    private void setLevelDifficulty() {
        int freq = LevelManager.instance.getMinigameFreq(minigame);

        switch(minigame) {
            case Minigame.EVASION:
                Gaben gaben = GameObject.FindObjectOfType<Gaben>();
                gaben.setSpawnRate(3 - 0.5f * freq);
                gaben.setShootSpeed(1f + 0.2f * freq);
                break;
            
            case Minigame.RYTHM:
                
                break;

            case Minigame.SLOT_MACHINE:

                break;

            case Minigame.TURN_BASED:
                TurnBased.Enemy enemy = GameObject.FindObjectOfType<TurnBased.Enemy>();
                enemy.setHealth(90f + 10*freq);
                enemy.setAttackDamage(15 + 5*freq);
                enemy.setSpecialDamage(15 + 5*freq);
                break;
        }
    }
}
