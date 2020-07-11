using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour

{
    public static GameState gameState;

    void Awake() {
        if (!gameState) {
            gameState = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private string[] minigames = {
        "Evasion",
        "Rythm",
        "SlotMachine",
        "TurnBased"
    };

    private string gameroomScene = "Gameroom";

    private Dictionary<string, int> minigameFreq = new Dictionary<string,int>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (string minigame in minigames) {
            minigameFreq.Add(minigame, 0);
        }

        StartCoroutine("stuff");
    }

    IEnumerator stuff() {
        while(true) {
            yield return new WaitForSeconds(2f);
            loadRandomMinigame();
        }
    }

    public void loadRandomMinigame() {
        int minFreq = 999;
        foreach (string minigame in minigames) {
            minFreq = Mathf.Min(minFreq, minigameFreq[minigame]);
        }

        List<string> lessFrequentMinigames = new List<string>();
        foreach (string minigame in minigames) {
            if(minigameFreq[minigame] == minFreq)
                lessFrequentMinigames.Add(minigame);
        }

        int choice = Random.Range(0, lessFrequentMinigames.Count);
        string chosen = lessFrequentMinigames[choice];
        minigameFreq[chosen]++;
        SceneManager.LoadScene(chosen);
    }

    public void loadGameRoom() {
        SceneManager.LoadScene(gameroomScene);
    }
}
