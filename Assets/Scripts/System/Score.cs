using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text ScoreText;


    int score;
    void Start()
    {
        ScoreText.text = score.ToString() + " Points";
    }


    public void AddPoints()
    {
            score += 100;
            ScoreText.text = score.ToString() + " Points";  
    }
}
