using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timeRemaining <= 0)
        {
            Player.enabled = false;
            GameOverScreen.SetActive(true);
            gancontroller.SetActive(false);
            playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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