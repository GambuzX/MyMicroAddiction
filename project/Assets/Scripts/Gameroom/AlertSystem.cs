using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AlertSystem : MonoBehaviour
{
    [SerializeField] private float minWait = 2f;
    [SerializeField] private float maxWait = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("setWarning");
    }

    IEnumerator setWarning() {
        float waitTime = Random.Range(minWait, maxWait);
        yield return new WaitForSeconds(waitTime);

        PlayableDirector director = GameObject.Find("TimelineController").GetComponent<PlayableDirector>();
        director.Play();
    }
}
