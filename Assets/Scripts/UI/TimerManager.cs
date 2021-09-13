using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [Header("Timer GameObject")]
    public TextMeshProUGUI timer;

    [Header("Timer Values")]
    public float timeValue    = 90f;
    public float timeIncrease = 10f;

    // Update is called once per frame
    void Update ()
    {
        if(timeValue > 0f)
        {
            timeValue -= Time.deltaTime;
        } else
        {
            timeValue = 0f;
            TimeFinished();
        }

        DisplayTime(timeValue);
    }

    void TimeFinished ()
    {

    }

    void DisplayTime (float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0f;           

        float minutes      = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds      = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timer.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void IncreaseTime ()
    {
        timeValue += 10f;
    }
}
