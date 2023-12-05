using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public TextMeshProUGUI myHighscore;
    // Start is called before the first frame update
    void Start()
    {
        myHighscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        setHighscore();
        setCurrentScore();
    }

    void setHighscore()
    {
        if (ObjectSpawnManager.gameObjectsInPlay.Count > PlayerPrefs.GetInt("Highscore", 0) )
        {
            PlayerPrefs.SetInt("Highscore", ObjectSpawnManager.gameObjectsInPlay.Count);
            myHighscore.text = PlayerPrefs.GetInt("Highscore",0 ).ToString();

        }
    }

    void setCurrentScore()
    {
        this.myText.text = ObjectSpawnManager.gameObjectsInPlay.Count.ToString();

    }

}
