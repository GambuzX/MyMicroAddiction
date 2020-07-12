using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToRoom()
    {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();

        levelManager.loadGameRoom();
    }
    
}
