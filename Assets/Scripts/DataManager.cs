using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string highScoringPlayerName;
    public int highScore;

    private string HIGHSCORE_SAVE_PATH;

    private void Awake()
    {
        HIGHSCORE_SAVE_PATH = Application.persistentDataPath + "/highscore.json";

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        LoadHighScore();
    }

    [System.Serializable]
    class HighScore
    {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScore(int score)
    {
        HighScore data = new HighScore();
        data.playerName = playerName;
        data.highScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(HIGHSCORE_SAVE_PATH, json);
    }

    public void LoadHighScore()
    {
        if (File.Exists(HIGHSCORE_SAVE_PATH))
        {
            string json = File.ReadAllText(HIGHSCORE_SAVE_PATH);

            HighScore data = JsonUtility.FromJson<HighScore>(json);

            highScoringPlayerName = data.playerName;
            highScore = data.highScore;
        } else
        {
            highScoringPlayerName = "n/a";
            highScore = 0;
        }
    }
}
