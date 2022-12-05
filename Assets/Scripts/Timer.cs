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

            if (timerText != null)
            {
                timerText.text = currentTime.ToString("f2").Replace(",", ":");
            }

            PlayerPrefs.SetString("timer", currentTime.ToString("f2").Replace(",", ":"));
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
