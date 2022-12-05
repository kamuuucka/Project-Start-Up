using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    private bool stopped = true;

    [SerializeField] float currentTime;
    [SerializeField] TMP_Text timerText;


    void Start()
    {
        currentTime = 0f;

        // Update is called once per frame
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            stopped = false;
        }

        if (!stopped)
        {
            currentTime += Time.deltaTime;

            timerText.text = currentTime.ToString("f2").Replace(",",":");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            stopped = true;
        }
    }
}
