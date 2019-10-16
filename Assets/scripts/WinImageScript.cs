using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinImageScript : MonoBehaviour
{
    public GameObject p1WinScreen;
    public GameObject p2WinScreen;
    public GameObject noWinScreen;

    private void Start()
    {
        p1WinScreen.SetActive(false);
        p2WinScreen.SetActive(false);
        noWinScreen.SetActive(false);

    }
    public void Reset()
    {
        p1WinScreen.SetActive(false);
        p2WinScreen.SetActive(false);
        noWinScreen.SetActive(false);

    }

    public void showResult(string tag)
    {
       // Debug.Log(tag);
        if (tag == "player1")
        {
            //set player2 win to visible
            p2WinScreen.SetActive(true);
        }
        else if (tag == "player2")
        {
            //set player1win to visible 
            p1WinScreen.SetActive(true);
        }
        else if (tag == "none")
        {
            
            noWinScreen.SetActive(true);
    
        }
    }
}
