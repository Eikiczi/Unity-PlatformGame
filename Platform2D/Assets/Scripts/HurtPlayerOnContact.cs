using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

    public int damageToGive;
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
            other.GetComponent<AudioSource>().Play();
           
            var player = other.GetComponent<PlayerController>();
            player.knockbackCounter = player.knockbackLength;

            if (other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
                Debug.Log("Player hurt");
            } else
            {
                player.knockFromRight = false;
                Debug.Log("Player hurt");
            }
                
        }
    }
}
