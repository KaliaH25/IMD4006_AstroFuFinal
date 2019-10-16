using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2CollisionController : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter2D(Collider2D victimCollider)
    {
        if (player.GetComponent<PunchScript>().isPunching && (player.GetComponent<PunchScript>() != null))
        {
           // Debug.Log(player.tag.ToString() + "collided with" + victimCollider.gameObject.tag.ToString());
            if (victimCollider.gameObject.tag == "player1")
            {
                //Debug.Log("Collision Happened with" + victimCollider.gameObject.tag.ToString());

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
}
