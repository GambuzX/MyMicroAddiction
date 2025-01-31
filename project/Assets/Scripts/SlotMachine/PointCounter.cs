﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public GameObject FirstDigit;
    public GameObject SecondDigit;
    public GameObject ThirdDigit;
    public GameObject FourthDigit;
    public GameObject FifthDigit;
    public GameObject SixthDigit;
    public GameObject PointsBox;
    public GameObject StartBox;
    public GameObject SlotAudio;

    public bool played = false;
    public int balanceChanges = 0;


    // Update is called once per frame
    public void countPoints()
    {
        StartCoroutine(Waiter());
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(5);

        string finalString = FirstDigit.GetComponent<UnityEngine.UI.Text>().text +
                             SecondDigit.GetComponent<UnityEngine.UI.Text>().text +
                             ThirdDigit.GetComponent<UnityEngine.UI.Text>().text +
                             FourthDigit.GetComponent<UnityEngine.UI.Text>().text +
                             FifthDigit.GetComponent<UnityEngine.UI.Text>().text +
                             SixthDigit.GetComponent<UnityEngine.UI.Text>().text;
        
        var characterCount= new Dictionary<char,int>();
        
        foreach(var c in finalString)
        {
            if(characterCount.ContainsKey(c))
                characterCount[c]++;
            else
                characterCount[c] = 1;
        }

        int max = 1;
        
        foreach (var c in finalString)
        {
            if (characterCount[c]>max)
            {
                max = characterCount[c];
            }
        }
        
        PointsBox.GetComponent<UnityEngine.UI.Text>().text = "Points : " + max;

        GameState gameState = GameObject.FindObjectOfType<GameState>();
        
        switch (max)
        {
            case 1:
                balanceChanges -= 200;
                gameState.updateMoney(-200);
                break;
            case 2:
                balanceChanges -= 50;
                gameState.updateMoney(-50);
                break;
            case 3:
                gameState.updateMoney(0);
                break;
            case 4:
                balanceChanges += 50;
                gameState.updateMoney(50);
                break;
            case 5:
                balanceChanges += 200;
                gameState.updateMoney(200);
                break;
            case 6:
                balanceChanges += 500;
                gameState.updateMoney(500);
                break;
        }
        played = true;
        
        StartBox.SetActive(true);
        SlotAudio.SetActive(false);

    }
}