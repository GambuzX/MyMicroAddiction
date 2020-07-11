using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipSlot : MonoBehaviour
{
    public void Skip()
    {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        
        levelManager.loadGameRoom();
    }
}
