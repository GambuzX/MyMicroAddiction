using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipSlot : MonoBehaviour
{
    public void Skip()
    {   
        PointCounter pointerCounter = GameObject.FindObjectOfType<PointCounter>();
        int balanceChange = pointerCounter.balanceChanges;
        if(!pointerCounter.played) {
            GameState.instance.addTransaction("Skipped the slot machine", Minigame.SLOT_MACHINE);
        }
        else if (balanceChange >= 200) {
            GameState.instance.addTransaction("Won big monei$$$ at skin slot machine", Minigame.SLOT_MACHINE);
        }
        else if (balanceChange > 0) {
            GameState.instance.addTransaction("Made some extra cash on the skin slot machine", Minigame.SLOT_MACHINE);
        }
        else if (balanceChange == 0) {
            GameState.instance.addTransaction("Broke even on the skin slot machine", Minigame.SLOT_MACHINE);
        }
        else if (balanceChange > -200) {
            GameState.instance.addTransaction("Got some cool new skins on the skin slot machine", Minigame.SLOT_MACHINE);
        }
        else {
            GameState.instance.addTransaction("Bought Dragon Lore on the skin slot machine", Minigame.SLOT_MACHINE);
        }
        
        LevelManager.instance.loadGameRoom();
    }
}
