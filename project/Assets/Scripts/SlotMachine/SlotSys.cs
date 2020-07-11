using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SlotSys : MonoBehaviour
{
    private char[] numbersRand = {'0', '1', '2', '3', '4', '5'};
    public Texture2D[] images;
    public Text slotNum;
    public Image slotImage;
    public float time;
    private int randNum;

    // Update is called once per frame
    void Update()
    {
        randNum = Random.Range(0, 6);
        slotNum.text = numbersRand[randNum].ToString();
        slotImage.sprite = Sprite.Create(images[randNum] ,new Rect(0, 0, images[randNum].width, images[randNum].height), new Vector2(0.5f, 0.5f));
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