using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI userScore;
    public Button backToMenu;

    void Awake()
    {
        string userName = PlayerPrefs.GetString("User");
        int highScore = PlayerPrefs.GetInt("HighScore");

        userScore.text = string.Format("{0}: {1}", userName, highScore);

        backToMenu.onClick.AddListener(_BackToMenu);
    }

    void _BackToMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
