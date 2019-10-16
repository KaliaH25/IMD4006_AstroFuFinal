using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameStateScript : MonoBehaviour
{
    public GameObject startMenuScreen;
    public GameObject gamePlayScreen;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        startMenuScreen.SetActive(true);
        gamePlayScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        
    }
    public void showStartMenu()
    {
        startMenuScreen.SetActive(true);
        gamePlayScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameOverScreen.GetComponent<WinImageScript>().Reset();
       // FindObjectOfType<AudioManager>().Play("bgMenu");
    }
    public void showGame()
    {
        startMenuScreen.SetActive(false);
        gamePlayScreen.SetActive(true);
        gameOverScreen.SetActive(false);
       // FindObjectOfType<AudioManager>().Play("bgMain");
    }
    public void showGameOver(string tag)
    {
        startMenuScreen.SetActive(false);
        gamePlayScreen.SetActive(false);
        gameOverScreen.SetActive(true);
       // FindObjectOfType<AudioManager>().Play("bgMenu");
        gameOverScreen.GetComponent<WinImageScript>().showResult(tag);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R)||Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            showStartMenu();
        }
        if (Input.anyKeyDown && startMenuScreen.activeSelf)
        {
            FindObjectOfType<AudioManager>().StopPlaying("bgMenu");
            showGame();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
