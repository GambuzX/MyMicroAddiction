using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmSys : MonoBehaviour
{
    public GameObject displayBox;
    public GameObject passBox;
    public GameObject pointBox;
    public GameObject winBox;
    public int rythmGen;
    public int waitingForKey;
    public int correctKey;
    public int countingDown;
    public int countingTime;
    public int startGame = 1;
    public float winPoints;


    // Update is called once per frame
    void Update()
    {
        if (winPoints >= 3.0f)
        {
            StopCoroutine(CountDown());
            winBox.GetComponent<Text>().text = "GOOD JOB. YOU WIN";
            startGame = 0;
        }

        if (winPoints <= -3.0f)
        {
            StopCoroutine(CountDown());
            winBox.GetComponent<Text>().text = "BAD JOB. YOU LOSE";
            startGame = 0;
        }
        
        
        if (startGame == 1)
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
                displayBox.transform.position = new Vector3(Random.Range(5, Screen.width-5), Random.Range(5, Screen.height-5), 0);
                displayBox.GetComponent<Text>().text = "[E]";
            }

            if (rythmGen == 2)
            {
                waitingForKey = 1;
                displayBox.transform.position = new Vector3(Random.Range(5, Screen.width-5), Random.Range(5, Screen.height-5), 0);
                displayBox.GetComponent<Text>().text = "[R]";
            }

            if (rythmGen == 3)
            {
                waitingForKey = 1;
                displayBox.transform.position = new Vector3(Random.Range(5, Screen.width-5), Random.Range(5, Screen.height-5), 0);
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
            winPoints += 1;
            pointBox.GetComponent<Text>().text = winPoints.ToString();
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }

        if (correctKey == 2)
        {
            countingDown = 2;
            passBox.GetComponent<Text>().text = "FAIL!";
            winPoints -= 0.5f;
            pointBox.GetComponent<Text>().text = winPoints.ToString();
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }
    }

    private IEnumerator CountDown()
    {
        countingTime = Random.Range(3, 6);
        yield return new WaitForSeconds(countingTime);
        if (countingDown == 1)
        {
            rythmGen = 4;
            countingDown = 2;
            passBox.GetComponent<Text>().text = "FAIL!";
            winPoints -= 0.5f;
            pointBox.GetComponent<Text>().text = winPoints.ToString();
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }
    }
}