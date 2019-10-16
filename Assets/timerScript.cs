using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public Text CountDownTimer;

    public float GameTime;

    // Start is called before the first frame update
    void Start()
    {
        GameTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime -= Time.deltaTime;

        string minutes = Mathf.Floor(GameTime / 60).ToString("0");
        string seconds = Mathf.RoundToInt(GameTime % 60).ToString("00");

        CountDownTimer.text = string.Format("{0}:{1}", minutes, seconds);

        if (GameTime <= 0)
        {
           
                FindObjectOfType<gameStateScript>().showGameOver("none");
            
        }
    }
}
