using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreGameOver;
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
            ScoreGameOver.text = score.ToString();
    }
}
