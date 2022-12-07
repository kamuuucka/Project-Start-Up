using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public bool stopped = true;

    [SerializeField] float currentTime;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text timerTextEnd;

    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {
        if (stopped)
        {
            if (timerTextEnd != null)
            {
                timerTextEnd.text = PlayerPrefs.GetString("timer");
            }
        }

        if (!stopped)
        {
            currentTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime - minutes * 60);

            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (timerText != null)
            {
                timerText.text = niceTime;
            }

            PlayerPrefs.SetString("timer", niceTime);
        }
    }

    public string GetTime()
    {
        return currentTime.ToString();
    }

    public bool GetBool()
    {
        return stopped;
    }

    public void SetBool(bool value)
    {
        stopped = value;
    }
}
