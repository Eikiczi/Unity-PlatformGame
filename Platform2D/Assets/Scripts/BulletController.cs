﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;

    public PlayerController player;

    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public int pointsForKill;

    public int damageToGive;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
        }
        Instantiate(impactEffect, other.transform.position, other.transform.rotation);
        Destroy(gameObject);
    }
}
