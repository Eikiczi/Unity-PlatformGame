using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FlyerEnemyMove.isAttacking = true;
            ArmadiloPatrol.isAttacking = true;            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FlyerEnemyMove.isAttacking = false;
            ArmadiloPatrol.isAttacking = false;
        }
    }
}
