using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public  int highScore;
    public  TMP_Text highScoreText;
    public static bool isNewRecord;
    private void Awake()
    {
        
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else highScore = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        isNewRecord = false;
        highScoreText.text = highScore + "";
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("highScore")<ScoreManager.score)
        {

            isNewRecord=true;
            PlayerPrefs.SetInt("highScore",ScoreManager.score);
        }
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = highScore + "";
    }

    public static void ResetHighScore()
    {
        
        PlayerPrefs.SetInt("highScore", 0);
    }
}
