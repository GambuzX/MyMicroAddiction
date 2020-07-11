using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Minigame {
    EVASION,
    RYTHM,
    SLOT_MACHINE,
    TURN_BASED
};

public class Minigames : MonoBehaviour
{
    private static MinigameInfo[] infos = {
        new MinigameInfo(Minigame.EVASION, "Evasion", "Evasion/new_foe", ""),
        new MinigameInfo(Minigame.RYTHM, "Rythm", "Rythm/new_foe", ""),
        new MinigameInfo(Minigame.SLOT_MACHINE, "SlotMachine", "SlotMachine/new_foe", ""),
        new MinigameInfo(Minigame.TURN_BASED, "TurnBased", "TurnBased/new_foe", "")
    };

    public static MinigameInfo getInfo(Minigame minigame) {
        foreach(MinigameInfo info in infos) {
            if (info.type == minigame)
                return info;
        }
        return null;
    }

    public static MinigameInfo[] getMinigamesInfo() {
        return infos;
    }
}
