using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionController : MonoBehaviour
{

  
    //link to the other player  to refer to their collision box/trigger/states idk?
    void OnTriggerEnter2D(Collider2D victimCollider)
    {
        if (victimCollider.gameObject.tag == "player1")
        {
            
            if (victimCollider.gameObject.GetComponent<playerStateHandler>() != null)
            {
                victimCollider.gameObject.GetComponent<playerStateHandler>().gotHit();//calls gotHit function for player 1
            }
            else
            {
                Debug.LogError("State Handler Missing");
            }
            
        }
        else if (victimCollider.gameObject.tag == "player2")
        {

            if (victimCollider.gameObject.GetComponent<playerStateHandler>() != null)
            {
                victimCollider.gameObject.GetComponent<playerStateHandler>().gotHit();//calls gotHit function for player 1
            }
            else
            {
                Debug.LogError("State Handler Missing");
            }

        }
    }
}
