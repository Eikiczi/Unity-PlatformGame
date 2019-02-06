using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    public float speed;

    public PlayerController player;

    public GameObject impactEffect;    

    public int damageToGive;

    private Rigidbody2D myRigidbody2D;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myRigidbody2D = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody2D.velocity = new Vector2(speed, myRigidbody2D.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
        }
        Instantiate(impactEffect, other.transform.position, other.transform.rotation);
        Destroy(gameObject);
    }

}
