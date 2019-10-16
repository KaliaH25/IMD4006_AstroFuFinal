using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateHandler : MonoBehaviour
{

    public GameObject player;
    public Animator animator;

    public KeyCode keyPunch, keyRotFwrd, keyRotBack;

    public bool isAlive;
    public bool isHit;
    public bool isPunching;
    public bool isRotForward;
    public bool isRotBackward;
    public bool isKO;

    public int attackDamage;

    int hitTimeOut=60;
    int hitTimer;

    int KOtimeOut=60;
    int KOtimer;
    public virtual void setKeys()
    {
        keyPunch = KeyCode.None;
        keyRotFwrd = KeyCode.None;
        keyRotBack = KeyCode.None;

    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        isHit = false;
        isPunching = false;
        isRotBackward = false;
        isRotForward = false;
        isKO = false;
        setKeys();

        KOtimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKO)
        {
            if (hitTimer > hitTimeOut)//players get access to controls after hit animation is complete
            {
                isHit = false;
                //Set backwards rotation state
                if (Input.GetKey(keyRotBack))
                {
                    isRotBackward = true;

                }
                if (Input.GetKeyUp(keyRotBack))
                {
                    isRotBackward = false;
                }

                //Set forward rotation state
                if (Input.GetKey(keyRotFwrd))
                {
                    isRotForward = true;
                }
                if (Input.GetKeyUp(keyRotFwrd))
                {
                    isRotForward = false;
                }

                if (Input.GetKey(keyPunch))
                {
                    player.GetComponent<PunchScript>().startPunch();//calls startPunch function from PunchScript 
                }


            }
            //animations, State should be set so only one state is true at the same time
            animator.SetBool("isBackwards", isRotBackward);
            animator.SetBool("isForwards", isRotForward);
            animator.SetBool("isAttacking", player.GetComponent<PunchScript>().isPunching);
            animator.SetBool("wasHit", isHit);

            hitTimer += 1;
        }
        else//if isKo is true
        {
            KOtimer += 1;
            playerKO();

        }

    }

    public void gotHit()
    {
        isHit = true;
        hitTimer = 0;
        
        if (player.GetComponent<healthHandler>() != null)
        {
            player.GetComponent<healthHandler>().takenDamage(attackDamage);
            //call damage function in healthHandlerscript
        }
        else
        {
            Debug.LogError("HealthHandler component missing!!!");
        }

    }
    public void playerKO()
    {
        if (KOtimer >= KOtimeOut)
        {
            FindObjectOfType<gameStateScript>().showGameOver(player.tag);
        }
        else
        {
            isAlive = false;
            isKO = true;
        }

        animator.SetBool("isDead", isKO);

        

        // call gamestate end function 
    }
}
