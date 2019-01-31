using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour {

    //The reason why we made these public was so that we can change these values in unity
    //instead of having to go into the script to adjust values.
    //All values can be viewed and edited in the unity inspector tabs
    //If we made them private we could only edit them in here making it less efficient


    //Movement Variables
    public float moveSpeed;
    public float jumpForce;
    public float moveSpeedSlowed;
    public float jumpForceSlowed;

    //Ammo Variables
    public int reload;
    public int ammo;

    //Hit boolean
    public bool hit;

    //Timer Variables
    public float timer;
    public float slowDuration;
    

    //Controls
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;

    //GroundCheck Variables
    public Transform gCheckPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    //Animator Refereences
    private Animator anim;

    //RigidBody Reference
    public Rigidbody2D rb;

    //Shooting variables
    public GameObject bullet;
    public Transform throwPoint;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>(); //Gets Animator Component and puts it in anim variable
	}
	
	// Update is called once per frame
	void Update () {

        //The player should not jump in the air, so this checks if it is on the ground
        isGrounded = Physics2D.OverlapCircle(gCheckPos.position, checkRadius, whatIsGround);

        //Move Left
        if ((Input.GetKeyDown(jump)) && isGrounded) //If KeyCode jump is pressed and the player is on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //sets y velocity of player to jumpforce value
        } 
        else if (Input.GetKey(left) && Input.GetKey(right)) //If both left and right are pressed the player stays in place
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (Input.GetKey(left)) //Moves player left
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right)) //Moves player right
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2 (0, rb.velocity.y); 
        }


        //Shooting component
        if ((Input.GetKeyDown(shoot)) && (ammo > 0)) //Checks if the player has ammo annd is pressing shoot
        {
            //Instantiates a game object (the bullet object) and makes a copy of it and puts it in bulletClone variable
            GameObject bulletClone = (GameObject) Instantiate(bullet, throwPoint.position, throwPoint.rotation);

            //Makes the direction of the bullet face the same dirrection of the player
            bulletClone.transform.localScale = transform.localScale;

            ammo -= 1; //Decreases ammo by one
        }

        if (rb.velocity.x < 0) //If the player is moving left makes the player face left
        {
            //Making the scale of the object negative flips its orientation
            //here we are making the x scale negative so that the player turns left
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else if (rb.velocity.x > 0) //If the player is moving right makes the player face right
        {
            transform.localScale = new Vector3(2, 2, 1);
        }

        //Slow Timer
        if (timer <= 0) //Checks if timer is lower than 0
        {
            // If timer is lower than 0, all values are normal
            moveSpeed = 5;
            jumpForce = 18;
            hit = false;
        }

        timer -= Time.deltaTime; //Decreases timer by 1 every second

        //Sets Grounded variable in animator equal to isGrounded variable in this script
        anim.SetBool("Grounded", isGrounded);
        //Sets Hit variable in animator equal to hit variable in this script
        anim.SetBool("Hit", hit);
	}

    //Checks collisions between other objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks for collision with bullet
        if (other.tag == "Bullet")
        {

            //decreases movespeed by moveSpeedSlowed value
            moveSpeed = moveSpeedSlowed;
            
            //Sets timer to slowDuration value
            timer = slowDuration;
            //Makes hit equal true
            hit = true;

            //When timer goes back to 0 all values are set to normal
            //So the player is slowed for the duration of the slowDuration value
            
            
        }

        //Checks for collision with power up
        if (other.tag == "Ammo")
        {
            ammo += reload; //Increases players ammo by reload value
        }
    }
}
