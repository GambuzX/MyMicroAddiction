using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SlotSys : MonoBehaviour
{
    private char[] numbersRand = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
    public Text slotNum;
    public float time;

    // Update is called once per frame
    void Update()
    {
        slotNum.text = numbersRand[Random.Range(0, numbersRand.Length)].ToString();
    }

    public void OffEnable()
    {
        Invoke("DelayNum", time);
    }

    public void OnEnable()
    {
        enabled = true;
    }

    void DelayNum()
    {
        enabled = false;
    }
}