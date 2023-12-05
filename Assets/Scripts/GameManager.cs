using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static UnityEvent gameLostEvent;
    public GameObject pauseButton;
    public GameObject lostText;
    public GameObject gameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameLostEvent ??= new UnityEvent();
        gameLostEvent.AddListener(SetGameLost);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGameLost()
    {
        lostText.SetActive(true);
        pauseButton.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void ResetGameOnClick()
    {
        Invoke("ResetGame", 1f * Time.deltaTime);
    }

    public void QuitGameOnClick()
    {
        Invoke("QuitGame", 1f * Time.deltaTime);
    }
    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ObjectSpawnManager.isAllowdToSpawnTrueEvent?.Invoke();
        ObjectSpawnManager.gameIsResetEvent?.Invoke();
        
    }

    void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        ObjectSpawnManager.isAllowdToSpawnTrueEvent?.Invoke();
        ObjectSpawnManager.gameIsResetEvent?.Invoke();
        Time.timeScale = 1;
        UnityEngine.AudioListener.pause = false;
    }
}
