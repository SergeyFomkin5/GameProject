using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    public GameObject GameOverScreen;
    public PlayerController playerController;
    public GameObject gancontroller;
    public Animator Player;
    [SerializeField] private GameObject Spawner;
    [SerializeField] private SpawnEnemy valueTime;
    [SerializeField] public int counteTimerWave;
    [SerializeField] private GameObject[] UiSprite;
    [SerializeField] private TMP_Text WaveCounte;
    private void Start()
    {
        timerIsRunning = true;
        WaveCounte.text = (counteTimerWave + 1).ToString();
    }

    void Update()
    {
        if (timeRemaining <= 0)
        {
            counteTimerWave++;
            WaveCounte.text=(counteTimerWave+1).ToString();
            if(counteTimerWave==1)
            {
                timeRemaining = 60;
                valueTime.value = 2;
            }
            if(counteTimerWave == 2)
            {
                valueTime.value = 1;
                timeRemaining = 30;
            }
        }
        if(counteTimerWave >= 3)
        {
            for(int i = 0; i < UiSprite.Length; i++)
            {
                UiSprite[i].SetActive(false);
            }
            counteTimerWave = 3;
            timerIsRunning=false;
            timeText.text = "Time is out";
            Spawner.SetActive(false);
            Player.enabled = false;
            GameOverScreen.SetActive(true);
            gancontroller.SetActive(false);
            playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            var Enemys = GameObject.FindGameObjectWithTag("Enemy");
            if (Enemys != null)
            {
                Destroy(Enemys);
            }
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeToDisplay < 0)
        {
            timeText.text = "Time is out";
        }
    }
}
/* */
