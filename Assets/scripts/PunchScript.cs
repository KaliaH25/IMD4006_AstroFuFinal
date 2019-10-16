using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private PunchBar punchBar;

    public bool isPunching;
    public bool canPunch;

    public float punchLength = 2f;//how long the punch takes
    public float punchCooldown = 4f;//how long player waits between punches 
    float punchCooldownTimer;

    private float whenCanPunch;
    private float punchDuration;

    private float timeOfPunch;
    


    // Start is called before the first frame update
    void Start()
    {
       
        isPunching = false;
        canPunch = true;

        whenCanPunch = Time.time;
        punchCooldownTimer = punchCooldown;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= punchDuration)
        {
            
            isPunching = false;
            if (player.GetComponent<playerStateHandler>() != null)
            {
                player.GetComponent<playerStateHandler>().isPunching = false;
            }
            else
            {
                Debug.LogError("State Handler Missing");
            }
        }
        if(Time.time >= whenCanPunch)
        {
            canPunch = true;
           

        }
        
        if(punchCooldownTimer >= punchCooldown)
        {
            punchCooldownTimer = punchCooldown;
        }
        else
        {
            punchCooldownTimer += 0.01f;
        }

        float punchbarPercent = punchCooldownTimer/punchCooldown;
      
        punchBar.SetSize(punchbarPercent);
       
    }

    public void startPunch()
    {
        if (canPunch)
        {
            punchCooldownTimer = 0f;
            canPunch = false;
            isPunching = true;
            timeOfPunch = Time.time;
            punchDuration = timeOfPunch+ punchLength;//find time that the punch will end
            whenCanPunch = punchDuration + punchCooldown;
            if (player.GetComponent<playerStateHandler>() != null)
            {
                player.GetComponent<playerStateHandler>().isPunching = true;
            }
            else
            {
                Debug.LogError("State Handler Missing");
            }
            
        }
        
        
    }
}
