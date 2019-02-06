using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;
    public static int playerHealth;

    private LevelManager levelManager;

    public bool isDead;
    public Slider healthBar;

    private LifeManager lifeSystem;


    // Use this for initialization
    void Start () {

        healthBar = GetComponent<Slider>();
        playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        levelManager = FindObjectOfType<LevelManager>();

        isDead = false;

        lifeSystem = FindObjectOfType<LifeManager>();
		
	}

    // Update is called once per frame
    void Update() {
        if (playerHealth <= 0 && !isDead )
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            lifeSystem.TakeLifs();
            isDead = true;
        }

        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }

       healthBar.value = playerHealth;

	}

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
    }

    public void FullHealth()
    {
        playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
    }
}
