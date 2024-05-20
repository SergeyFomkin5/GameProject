using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMP_Text ScoreText;
    public static Score instance;

    int score;
    void Start()
    {
        ScoreText.text = score.ToString() + " Points";
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPoints()
    {
            score += 100;
            ScoreText.text = score.ToString() + " Points";  
    }
}
