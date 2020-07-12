using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager> {

    private string gameroomScene = "Gameroom";
    [SerializeField] private Minigame[] minigames;

    private Dictionary<Minigame, int> minigameFreq = new Dictionary<Minigame,int>();

    // Start is called before the first frame update
    void Start()
    {
        MinigameInfo[] infos = Minigames.getMinigamesInfo();
        minigames = new Minigame[infos.Length];
        for (int i = 0; i < minigames.Length; i++)
            minigames[i] = infos[i].type;

        foreach (Minigame minigame in minigames) {
            minigameFreq.Add(minigame, 0);
        }
    }

    public Minigame chooseRandomMinigame() {
        int minFreq = 999;
        foreach (Minigame minigame in minigames) {
            minFreq = Mathf.Min(minFreq, minigameFreq[minigame]);
        }

        List<Minigame> lessFrequentMinigames = new List<Minigame>();
        foreach (Minigame minigame in minigames) {
            if(minigameFreq[minigame] == minFreq)
                lessFrequentMinigames.Add(minigame);
        }

        int choice = Random.Range(0, lessFrequentMinigames.Count);
        Minigame chosen = lessFrequentMinigames[choice];
        minigameFreq[chosen]++;
        return chosen;
    }

    public void loadGameRoom() {
        SceneManager.LoadScene(gameroomScene);
    }

    public void loadLevel(string level) {
        SceneManager.LoadScene(level);
    }

    public void gameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public int getMinigameFreq(Minigame m) {
        return minigameFreq.ContainsKey(m) ? minigameFreq[m] : 0;
    }
}
