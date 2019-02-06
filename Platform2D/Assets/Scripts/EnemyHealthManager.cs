using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealt;
    public GameObject deathEffect;
    public int pointsForDeath;
	
	// Update is called once per frame
	void Update () {
        if(enemyHealt <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsForDeath);
            Destroy(gameObject);
        }	
	}

    public void GiveDamage(int damageToGive)
    {
        enemyHealt -= damageToGive;
        GetComponent<AudioSource>().Play();
    }
}
