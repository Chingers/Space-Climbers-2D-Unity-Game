using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    //Start and Quit Funtions are attatched to buttons and are called when the buttons are pressed in the game

    //holds name of levels in game
    public string GameLevel1;
    public string GameLevel2;
    public string GameLevel3;

    //Holds name for instructions
    public string instructions;
    
    public int LevelNumber;
	
	public void StartGame()
    {
        //Holds Randomly generated number between 1 and 4, not including 4
        LevelNumber = Random.Range(1, 4);

        //Switch statement that goes to different levels based on the random number generated 
        switch (LevelNumber)
        {
            case 1:
                SceneManager.LoadScene(GameLevel1); //Goes to level 1
                break;

            case 2:
                SceneManager.LoadScene(GameLevel2); //Goes to level 2
                break;

            case 3:
                SceneManager.LoadScene(GameLevel3); //Goes to level 3
                break;
                
        }
        
    }

    public void QuitGame() //Quits game
    {
        Application.Quit();
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene(instructions);
    }
}
