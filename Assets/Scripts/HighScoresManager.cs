using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataManager;

public class HighScoresManager : MonoBehaviour
{
    public TextMeshProUGUI highScoresList;
    void Awake()
    {
        Instance.LoadHighScores();

        List<HighScore> highScores = Instance.highScores;

        if(highScores.Count > 0)
        {
            for (var i = 0; i < highScores.Count; i++)
            {
                highScoresList.text += $"{i + 1}. {highScores[i].playerName}: {highScores[i].highScore} <br>";

            }
        } else
        {
            highScoresList.text = "No high scores saved";
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene(1);
    }
}
