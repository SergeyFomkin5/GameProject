using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    Timer timer;
    public GameObject GameOverScreen;


    private void Start()
    {
        timer = GetComponent<Timer>();
    }

    void Update()
    {
        if (timer.timeRemaining <= 0)
        {
            Debug.Log("something happend");
            Time.timeScale = 0f;
            GameOverScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
