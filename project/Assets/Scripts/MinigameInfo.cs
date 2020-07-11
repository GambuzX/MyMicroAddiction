using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameInfo
{
    public Minigame type;
    public string sceneName;
    public string newFoeImage;
    public string purchaseHistoryImage;

    public MinigameInfo(Minigame type, string sceneName, string newFoeImage, string purchaseHistoryImage) {
        this.type = type;
        this.sceneName = sceneName;
        this.newFoeImage = newFoeImage;
        this.purchaseHistoryImage = purchaseHistoryImage;
    }
}
