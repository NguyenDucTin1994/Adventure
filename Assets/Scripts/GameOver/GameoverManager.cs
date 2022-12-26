using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameoverManager : MonoBehaviour
{
    public string level1;
    public string MainMenu;

    public GameObject gameOverScreen;
    public TMP_Text gameOverText;
    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthManager.healthCurrent<=0|| EndPointController.isVictory)
        {
            gameOverScreen.SetActive(true);
            if (EndPointController.isVictory)
            {
                gameOverText.text = "Victory!";
            }
            else
                gameOverText.text = "Game  Over!";
            if(HighScoreManager.isNewRecord)
            {
                highScoreText.text="New record : " + PlayerPrefs.GetInt("highScore");
            }
            else
                highScoreText.text = null;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(level1);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
