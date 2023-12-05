using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;

        UnityEngine.AudioListener.pause = true;

    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        UnityEngine.AudioListener.pause = false;

        
    }
}
