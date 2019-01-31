using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed; //Holds speed of bullet
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Makes bullet move to whatever direction its facing
        rb.velocity = new Vector2(bulletSpeed * transform.localScale.x, 0);
	}

    //Checks for Collisions in the game
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the bullet collides with a player or  platform, it will be destroyed
        if((other.tag == "Bullet") || (other.tag == "Player1") || (other.tag == "Player2") || (other.tag == "Platform"))
        {
            Destroy(gameObject); //Destroys object
        }

       
        
    }
}
