using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Checks for collisions in game
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the portal collides with player 1, meaning player 1 wins
        if (other.tag == "Player1")
        {
            //This runs the P1Wins method that is located in the GameManager Script
            FindObjectOfType<GameManager>().P1Wins(); 
        }
        //If the portal collides with player 2, meaning player 2 wins
        if (other.tag == "Player2")
        {
            //This runs the P2Wins method that is located in the GameManager Script
            FindObjectOfType<GameManager>().P2Wins();
        }

        //Go to GameManager script to see what functions do
    }
}
