using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpHeight;
    private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    private bool doubleJumped;

    public Transform firePoint;
    public GameObject bullet;

    private Animator anim;

    public float shotDelay;
    private float delayCounter;

    public float knockback;
    public float knockbackCounter;
    public float knockbackLength;
    public bool knockFromRight;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update () {

        if (grounded)
        {
            doubleJumped = false;
        }

        anim.SetBool("Grounded", grounded);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            
        }

        if(knockbackCounter <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        } else
        {
            if (knockFromRight)
                 GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);   
            if (!knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            knockbackCounter -= Time.deltaTime;
        }
        

        //Shooting
		if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            delayCounter = shotDelay;
        }

        if (Input.GetButton("Fire1"))
        {
            delayCounter -= Time.deltaTime;

            if(delayCounter <= 0)
            {
                delayCounter = shotDelay;
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            }

        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
	}

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
