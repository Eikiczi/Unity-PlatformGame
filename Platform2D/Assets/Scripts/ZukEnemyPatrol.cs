using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZukEnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    //wall check
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    public bool walled;

    //edge check
    private bool notAtEdge;
    public Transform egdeCheck;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        walled = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(egdeCheck.position, wallCheckRadius, whatIsWall);


        if (walled || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
