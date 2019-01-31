using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Variables that hold a reference to Objects in game
    public GameObject player1;
    public GameObject player2;
    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject portal;

    //Variables that hold key codes that you can edit 
    public KeyCode returnToMenu;
    public KeyCode restart;
    public KeyCode NextLevel;

    //Boolean value that decides whether someone has won a level
    public bool GameOver;

    //Strings that hold name of levels and scenes
    public string startMenu;
    public string level1;
    public string level2;
    public string level3;
    public string level4;

    //Variables that handle with switching levels
    public int numLevel;
    public string nameOfLevel;
    public int nextLevel;
    
    //Start is run right when script is run
	// Use this for initialization
	void Start () {

        GameOver = false; //Makes sure that GameOver is false at start of all rounds

        //Gets name of scene and puts it in nameOfLevel variable
        nameOfLevel = SceneManager.GetActiveScene().name;

        if ((nameOfLevel.Equals(level1))) //Checks if the current level you are in is level 1
        {
            numLevel = 1; //gives value to numLevel variable that corresponds with the current level they are in
        }

        if ((nameOfLevel).Equals(level2)) //Checks if the current level you are in is level 2
        {
            numLevel = 2;
        }

        if ((nameOfLevel).Equals(level3)) //Checks if the current level you are in is level 3
        {
            numLevel = 3;
        }

        if ((nameOfLevel).Equals(level4)) //Checks if the current level you are in is level 4
        {
            numLevel = 4;
        }
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(restart)) //Checks if keycode restart is pressed
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reloads current scene
        }

        if (Input.GetKeyDown(returnToMenu)) //Checks if keycode returnToMenu is pressed
        {
            SceneManager.LoadScene(startMenu); //Reloads Menu scene
        }


        if ((Input.GetKeyDown(NextLevel)) && (GameOver == true)) //Checks if KeyCode NextLevel is pressed, and if someone won the level
        {
            //Switch statement that does something different according to the current level
            switch (numLevel)
            {
                case 1: //Means your in level 1
                    nextLevel = Random.Range(1, 3); //Generates a random number from 1 to 3, not including 3

                    if (nextLevel == 1) //If random number is 1, loads scene 2
                    {
                        SceneManager.LoadScene(level2);
                    }
                    else if  (nextLevel == 2) //If random number is 2, loads scene 3
                    {
                        SceneManager.LoadScene(level3);
                    }

                    break;

                case 2: //Means your in level 2
                    nextLevel = Random.Range(1, 3);

                    if (nextLevel == 1) //If random number is 1, loads scene 1
                    {
                        SceneManager.LoadScene(level1);
                    }
                    else if (nextLevel == 2) //If random number is 2, loads scene 3
                    {
                        SceneManager.LoadScene(level3);
                    }
                    break;

                case 3: //Means your in level 3
                    nextLevel = Random.Range(1, 3); 

                    if (nextLevel == 1) //If random number is 1, loads scene 1
                    {
                        SceneManager.LoadScene(level1);
                    }
                    else if (nextLevel == 2) //If random number is 2, loads scene 2
                    {
                        SceneManager.LoadScene(level2);
                    }
                    break;

                case 4: //Means your in level 4

                    break;
            }
        }

	}

    //Methods that are used when a player wins

    //When player 1 wins
    public void P1Wins() 
    {
        //Activates Game Over Screen, de-activates player 1 and portal, and sets GameOver to be true
        player1.SetActive(false);
        portal.SetActive(false);
        p1Wins.SetActive(true);
        GameOver = true;
    }

    //When player 2 wins
    public void P2Wins()
    {
        //Activates Game Over Screen, de-activates player 2 and portal, and sets GameOver to be true
        player2.SetActive(false);
        portal.SetActive(false);
        p2Wins.SetActive(true);
        GameOver = true;
    }
}
