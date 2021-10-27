using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {

	// The list of enemies prefabs stored 
	public GameObject[] enemy;    

	//to store random enemy at runtime to instantiate
	private GameObject tempEnemy;

	//Get the button to diable/enable it
	public GameObject nextWaveCanvas;

	//Get the button to diable/enable it
	public GameObject restartCanvas;

	//bool to check if game was paused
	public bool wasPaused = false;

	//refresh current time bool
	bool refreshCurrent;

	// Wave Number that is to be spawned
	int waveNumber;

	//bool to check whether wave is currently spwaning or not
	bool isSpawning;

	//variable to store difference
	float diffrence = 0;

	//current difference time
	float currentminus ;

	//minus value for pause game
	float minus;

	//Getting time in seconds for single spawn 
	float spawnStartTime;

	//Average time randomly generated to spawn next enemy
	float nextEnemy;

	//Current time during wave
	float currentTime = 0;

	//store text to display remaining wave time
	public Text remainingTimeText;

    public int waveTimeIncrease = 10;
    public int waveStartTime = 5;

	void Start ()
	{

		//Set referesh time to false;
		refreshCurrent = false;

		//minus value to zero
		minus = 0;

		//Initiate waveNumber to 0
		waveNumber = 0;

		//Set isSpawning to true
		isSpawning = true;

		//get time in seconds
		spawnStartTime = getSeconds();

		//set nextEnemy
		nextEnemy = 2;
	}

	void Update()
	{
		//pauseSpawn ();

		if(!FindObjectOfType<Pause>().gamePaused)	
			Spawn ();
	}


	void Spawn ()
	{
		if (isSpawning) {


				//store current time to compare
				currentTime = getSeconds ();
		
			    

			if (currentTime - spawnStartTime < (((waveNumber * waveTimeIncrease) + waveStartTime + diffrence))) {

				//Setting the remaining time text
				remainingTimeText.text = "Survive till: " + (((waveNumber * waveTimeIncrease) + waveStartTime + diffrence) - (currentTime - spawnStartTime)).ToString();

				//getting random enemy 
				tempEnemy = enemy [UnityEngine.Random.Range (0, waveNumber+1)];

				//condition to spawn next enemy after random seconds have passed
				if (currentTime - spawnStartTime >= nextEnemy) {

					// Create an instance of the enemy prefab at the randomly
					Instantiate (tempEnemy, new Vector3 (UnityEngine.Random.Range (-30f, 30f), UnityEngine.Random.Range (5f, 15f)), Quaternion.identity);

					//range given it the function to set the spawn time of each enemy after one enemy is spawned
					//to increase difficulty range can be decreased e.g (0f,3f) enemy will spawn from after 0 seconds till 5f randomly
					nextEnemy += (UnityEngine.Random.Range (0f, 5f)) + diffrence;
				}


			} else {



				GameObject[] allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");

				//GetAllRemaining Enemies
				foreach (GameObject e in allEnemies)
					Destroy (e);

				//Clear text
				remainingTimeText.text = "";

				//Stop the spawning
				isSpawning = false;

				//increase the wave to 1
				waveNumber++;

				//condition to check whether waveNumber does not exceed enemy array list
				if (waveNumber < enemy.Length) {
					
					//SetActive the button to be clicked and start next wave
					nextWaveCanvas.SetActive(true);

				} else {
					
					//SetActive the restart button
					restartCanvas.SetActive(true);

				}
			}


		}
	}

	//Function for getting current time
	float getSeconds()
	{
		return float.Parse(DateTime.Now.Second.ToString()) + (float.Parse(DateTime.Now.Hour.ToString()) * 60 * 60) + (float.Parse(DateTime.Now.Minute.ToString()) * 60) ;
	}

	//Function for button when clicked
	public void nextWave()
	{

		//spawn next wave
		isSpawning = true;

		//reset the timer
		spawnStartTime = getSeconds ();

		//reset difference
		diffrence = 0;

		//disables the canvas on press
		nextWaveCanvas.SetActive (false);

		//set nextEnemy to 3 so after starting new wave first enemy will appear after 3 seconds
		nextEnemy = 3;

	}

	//Function to restart game
	public void restart()
	{
        PlayerPrefs.DeleteAll();
		//Restart game
		SceneManager.LoadScene("game");

	}

	public void pauseSpawn()
	{
		if (FindObjectOfType<Pause>().gamePaused) {

			    minus = getSeconds ();

		}
        else
        {
				
			     currentminus = getSeconds ();
			    
			     //take out the difference between pause time
			     diffrence  += (currentminus - minus);
			  
		}


    }

}
