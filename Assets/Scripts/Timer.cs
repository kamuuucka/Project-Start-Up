using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public bool stopped = true;

    [SerializeField] float currentTime;
    [SerializeField] TMP_Text timerText;


    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {
        /*        if (Input.GetKey(KeyCode.T))
                {
                    stopped = false;
                }*/

        if (stopped)
        {
            Debug.Log("timer stopped");
            Debug.Log(currentTime.ToString());
        }

        if (!stopped)
        {
            currentTime += Time.deltaTime;

            timerText.text = currentTime.ToString("f2").Replace(",", ":");
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

/*        if (value == true)
        {
            Debug.Log("timer stopped");
        }*/

        if (value == false)
        {
            Debug.Log("timer started");
        }
    }
}
