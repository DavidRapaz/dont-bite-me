using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public Button playButton;
    public Button scoresButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(_Play);
        scoresButton.onClick.AddListener(_ShowScores);
        quitButton.onClick.AddListener(_Quit);
    }

    void _Play ()
    {
        SceneManager.LoadScene("level_01");
    }

    void _ShowScores ()
    {
        SceneManager.LoadScene("HighScore");
    }

    void _Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
