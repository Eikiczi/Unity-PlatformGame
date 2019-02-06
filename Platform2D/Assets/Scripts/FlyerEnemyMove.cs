using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerEnemyMove : MonoBehaviour {

    private PlayerController thePlayer;

    public float moveSpeed;
    public float playerRange;
    public bool moveRight;

    //detect where is player
    public LayerMask playerLayer;
    public bool playerInRange;

    //detect animation
    public static bool isAttacking = false;
    private Animator anim;

    //where is player detecter
    public Transform playerCheck;
    public float playerCheckRadius;
    public LayerMask whatIsPlayer;
    public bool playered;

    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        anim = GetComponent<Animator>(); 
    }
	
	// Update is called once per frame
	void Update () {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        playered = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);

        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
        }

        if (isAttacking)
        {
            anim.SetBool("isAttacking", true);
        } else
        {
            anim.SetBool("isAttacking", false);
        }

        if (playered)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }

}
