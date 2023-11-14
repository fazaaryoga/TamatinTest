using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore");
        highScoreText.SetText("High Score: " +  (highScore >= 0 ? highScore : 0));
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
