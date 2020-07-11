using System;
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

        StartBox.SetActive(true);

    }
}