using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Checks Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroys the power up if it collides with a player
        if ((other.tag == "Player1") || (other.tag == "Player2"))
        {
            Destroy(gameObject);
        }
    }
}
