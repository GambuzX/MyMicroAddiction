using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RythmSys : MonoBehaviour
{
    public GameObject displayBox;
    public GameObject displayBoxImage;

    public GameObject passBox;
    public GameObject pointBox;
    public int rythmGen;
    public int waitingForKey;
    public int correctKey;
    public int countingDown;
    public int countingTime;
    private int start = 0;
    private int failCounter = 0;
    public int MIN = 3;
    public int MAX = 6;

    private void Start()
    {
        StartCoroutine(Waiter());
    }

    private IEnumerator Waiter()
    {
        displayBox.GetComponent<Text>().text = "";
        yield return new WaitForSecondsRealtime(4);
        start = 1;
    }

    // Update is called once per frame
    void Update()
    {        
        if (start == 1)
        {
            RythmMainGameStart();
        }
    }

    private void RythmMainGameStart()
    {
        if (waitingForKey == 0)
        {
            rythmGen = Random.Range(1, 4);
            countingDown = 1;
            StartCoroutine(CountDown());
            if (rythmGen == 1)
            {
                waitingForKey = 1;

                displayBoxImage.SetActive(true);

                Vector3 randVec = new Vector3(Random.Range(20, Screen.width - 20), Random.Range(20, Screen.height - 20), 0);

                displayBox.transform.position = randVec;
                displayBoxImage.transform.position = new Vector3(randVec.x, randVec.y - 13, randVec.z);

                displayBox.GetComponent<Text>().text = "[E]";
            }

            if (rythmGen == 2)
            {
                waitingForKey = 1;

                displayBoxImage.SetActive(true);

                Vector3 randVec = new Vector3(Random.Range(20, Screen.width - 20), Random.Range(20, Screen.height - 20), 0);

                displayBox.transform.position = randVec;
                displayBoxImage.transform.position = new Vector3(randVec.x, randVec.y - 13, randVec.z);

                displayBox.GetComponent<Text>().text = "[R]";
            }

            if (rythmGen == 3)
            {
                waitingForKey = 1;

                displayBoxImage.SetActive(true);

                Vector3 randVec = new Vector3(Random.Range(20, Screen.width - 20), Random.Range(20, Screen.height - 20), 0);

                displayBox.transform.position = randVec;
                displayBoxImage.transform.position = new Vector3(randVec.x, randVec.y - 13, randVec.z);

                displayBox.GetComponent<Text>().text = "[T]";
            }
        }

        if (rythmGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("Ekey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (rythmGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("Rkey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (rythmGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("Tkey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    private IEnumerator KeyPressing()
    {
        rythmGen = 4;
        if (correctKey == 1)
        {
            countingDown = 2;
            passBox.GetComponent<Text>().text = "PASS!";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            displayBoxImage.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }

        if (correctKey == 2)
        {
            countingDown = 2;
            passBox.GetComponent<Text>().text = "FAIL!";
            
            GameState gameState = GameObject.FindObjectOfType<GameState>();
            gameState.updateMoney(-20);
            failCounter++;
            pointBox.GetComponent<Text>().text = failCounter.ToString();
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            displayBoxImage.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }
    }

    private IEnumerator CountDown()
    {
        countingTime = Random.Range(MIN, MAX);
        yield return new WaitForSeconds(countingTime);
        if (countingDown == 1)
        {
            rythmGen = 4;
            countingDown = 2;
            passBox.GetComponent<Text>().text = "FAIL!";
            GameState gameState = GameObject.FindObjectOfType<GameState>();
            gameState.updateMoney(-20);
            failCounter++;
            pointBox.GetComponent<Text>().text = failCounter.ToString();
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            displayBoxImage.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }
    }
}