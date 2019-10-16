using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class moveScript : MonoBehaviour
{
    
    public Animator animator; //this is your animator!!! need to find what you're animating? ctrl+f the word animator
    public playerStateHandler playerState;

    public float moveSpeed;
    public float boost;
    public float rotationSpeed;

    public Rigidbody2D ball;

    public float ballAngle;

    public int direction;
    public Vector2 angularVelocity;



    // Start is called before the first frame update
    void Start()
    {
        //p1HealthBox.text = p1Health.ToString();

        ball = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //p1HealthBox.text = p1Health.ToString();

        /*if (p1Health <= 0)
        {
            // p2 wins
        }*/

        ballAngle = ball.rotation;
        
        angularVelocity.x = direction * boost;
        angularVelocity.y = 0;
        
        

        //rotations
        if (playerState.isRotBackward)
        {
            float rotateUp = 1 * rotationSpeed;
            
            ball.AddTorque(rotateUp, ForceMode2D.Force);
        }
        if (playerState.isRotForward)
        {
            float rotateDown = -1 * rotationSpeed;

            ball.AddTorque(rotateDown, ForceMode2D.Force);
        }
        if (playerState.isPunching)
        {
            ball.AddRelativeForce(angularVelocity, ForceMode2D.Force);
        }
    }

}
