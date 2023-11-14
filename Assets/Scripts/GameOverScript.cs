using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore");
        float score = PlayerPrefs.GetFloat("Score");

        highScoreText.SetText("High Score: " +  highScore);
        scoreText.SetText("Score: " + score);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
