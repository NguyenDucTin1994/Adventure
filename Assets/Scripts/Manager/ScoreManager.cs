using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI textOfScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textOfScore=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score<0)
            score = 0;
        textOfScore.text = ""+score;
    }

    public static void AddPoint(int pointToAdd)
    { 
        score += pointToAdd; 
    }
}
