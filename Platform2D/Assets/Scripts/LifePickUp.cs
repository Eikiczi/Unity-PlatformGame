using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour {

    private LifeManager lifeSystem;
    public AudioSource pickupSound;
    public GameObject pickupEffect;

	// Use this for initialization
	void Start () {
        lifeSystem = FindObjectOfType<LifeManager>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            lifeSystem.GiveLife();
            pickupSound.Play();
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
