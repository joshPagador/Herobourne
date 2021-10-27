using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHealthBar : MonoBehaviour {

	public Image healthBar;
	float maxHealth = 300f;
	public float health;
	public GameObject enemyManager;
	public GameObject gameOverCanvas;


	// Use this for initialization
	void Start()
	{
		enemyManager.GetComponent<EnemyManager> ();
		GetComponent<HealthBarScript> ();
		health = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		healthBar.fillAmount = health / maxHealth;

		if (health == 0) {
			GameOver ();
		}
	}


	public void GameOver()
	{
		enemyManager.GetComponent<EnemyManager> ().enabled = false;
		Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
		gameOverCanvas.SetActive (true);
		Time.timeScale = 0f;
	}
}

