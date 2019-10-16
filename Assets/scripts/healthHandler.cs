using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;


    public GameObject player;

    public float pMaxHealth = 10f;
    public float pMinHealth = 0f;
    public float playerHealth;

   

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = pMaxHealth;//set playerHealth 

        float healthPercent = playerHealth / pMaxHealth;
        //float health = 1f;
        healthBar.SetSize(healthPercent);
    }

    void Update()
    {//update health bar
        float healthPercent = playerHealth / pMaxHealth;
        //Debug.Log(healthPercent.ToString());
        healthBar.SetSize(healthPercent);
    }

    public void takenDamage(int damage)
    {
        playerHealth -= damage;//reduce player health by damage variable (passed through playerStateHandler)
        if (playerHealth <= pMinHealth)
        {
            if (player.GetComponent<playerStateHandler>() != null)
            {
                player.GetComponent<playerStateHandler>().playerKO();
            }
            else
            {
                Debug.LogError("State Handler Missing");
            }
                
        }
    }

    
}
