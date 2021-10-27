using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

	public bool gamePaused = false;  //whether or not game is paused
    public GameObject pauseMenuCanvas;
    public GameObject settingsCanvas;

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gamePaused = !gamePaused;  // if game paused is true, set it to false <> if game paused is false, set it to true ----> when pressing escape

			//Call enemy function
			FindObjectOfType<EnemyManager> ().pauseSpawn ();
		}

     
        if (gamePaused)
        {
            pauseMenuCanvas.SetActive(true); //sets pause canvas to be visible
            Time.timeScale = 0f;  //freezes the game
        }
        else
        {
            settingsCanvas.SetActive(false);
            pauseMenuCanvas.SetActive(false); // sets pause canvas to be invisible
            Time.timeScale = 1f; //unfreeze game  - moves in realtime
        }



    }


    public void Resume()
    {
        gamePaused = false; //function that is called upon in game when resume button is pressed 

		//Call enemy function
		FindObjectOfType<EnemyManager> ().pauseSpawn ();
    }
}
