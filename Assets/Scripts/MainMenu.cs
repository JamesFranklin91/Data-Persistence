using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField nameInput;

    private void Start()
    {
        nameInput.onValueChanged.AddListener(delegate { HandleNameInputChange(); });
    }

    public void StartGame()
    {
        if (DataManager.Instance != null && DataManager.Instance.getPlayerName() != "")
        {
            SceneManager.LoadScene(1);
        }
    }

    private void HandleNameInputChange()
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.setPlayerName(nameInput.text);
        }
    }
}
