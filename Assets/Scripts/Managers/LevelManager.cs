using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Timer")]
    public TextMeshProUGUI timer;

    public float timeValue = 20f;
    public float timeIncrease = 5f;

    [Header("Score")]
    public TextMeshProUGUI score;

    [Header("HighScore UI")]
    public GameObject finishUI;
    public InputField inputUserName;
    public Button saveScore;

    [Header("TryAgain UI")]
    public GameObject tryAgainUI;
    public Button tryAgain;
    public Button quitToMenu;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale   = 1;

        saveScore.onClick.AddListener(_SaveScore);
        tryAgain.onClick.AddListener(_TryAgain);
        quitToMenu.onClick.AddListener(_QuitToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0f)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0f;
            _TimeFinished();
        }

        _DisplayTime(timeValue);
    }

    void _TimeFinished()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            int highscore = PlayerPrefs.GetInt("HighScore");

            if (highscore < Int32.Parse(score.text))
            {
                finishUI.SetActive(true);
            } else
            {
                tryAgainUI.SetActive(true);
            }
        } else 
        {
            finishUI.SetActive(true);
        }
    }

    void _DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0f;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timer.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    void _SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", Int32.Parse(score.text));
        PlayerPrefs.SetString("User", inputUserName.text);

        PlayerPrefs.Save();

        SceneManager.LoadScene("MainMenu");
    }

    void _TryAgain ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    void _QuitToMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseTime()
    {
        timeValue += 2f;
    }
}
