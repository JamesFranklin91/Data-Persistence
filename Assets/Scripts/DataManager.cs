using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    //public string highScoringPlayerName;
    //public int highScore;
    public List<HighScore> highScores = new List<HighScore>();

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

        LoadHighScores();
    }

    [System.Serializable]
    public class SaveData
    {
        public List<HighScore> highScores = new List<HighScore>();
    }

    [System.Serializable]
    public class HighScore
    {
        public string playerName;
        public int highScore;

        public HighScore(string name, int score)
        {
            this.playerName = name;
            this.highScore = score;
        }
    }

    public void SaveHighScores(List<HighScore> highScores)
    {
        SaveData saveData = new SaveData();
        saveData.highScores = highScores;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(HIGHSCORE_SAVE_PATH, json);
        LoadHighScores();
    }

    public void LoadHighScores()
    {
        if (File.Exists(HIGHSCORE_SAVE_PATH))
        {
            string json = File.ReadAllText(HIGHSCORE_SAVE_PATH);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScores = data.highScores;
        } else
        {
            SaveHighScores(highScores);
        }
    }

    void PrintHighScores()
    {
        foreach (HighScore highScore in highScores)
        {
            Debug.Log($"{highScore.playerName}: {highScore.highScore}");
        }
    }
}
