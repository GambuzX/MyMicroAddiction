using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class AlertSystem : MonoBehaviour
{
    [SerializeField] private float minWait = 2f;
    [SerializeField] private float maxWait = 10f;

    [SerializeField] Image newFoeImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("setWarning");
    }

    IEnumerator setWarning() {
        float waitTime = Random.Range(minWait, maxWait);
        yield return new WaitForSeconds(waitTime);

        LevelManager levelManager = LevelManager.instance;
        Minigame chosenMinigame = levelManager.chooseRandomMinigame();
        MinigameInfo info = Minigames.getInfo(chosenMinigame);
        newFoeImage.sprite = Resources.Load<Sprite>(info.newFoeImage);

        PlayableDirector director = GameObject.Find("TimelineController").GetComponent<PlayableDirector>();
        director.Play();
        
        yield return new WaitForSeconds((float)director.duration);
        levelManager.loadLevel(info.sceneName);
    }
}
