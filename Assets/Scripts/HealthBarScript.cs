using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    public Image healthBar;
    float maxHealth = 500f;
    public float health;
	public GameObject gameOverCanvas;
	public GameObject enemyManager;

	// Use this for initialization
	void Start ()
    {
		enemyManager.GetComponent<EnemyManager> ();
        healthBar = GetComponent<Image>();
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.fillAmount = health / maxHealth;

		if (health <= 0) {
			Destroy (GameObject.FindGameObjectWithTag ("Player"));
			GameOver ();
		}
	}

	public void GameOver()
	{
		enemyManager.GetComponent<EnemyManager> ().enabled = false;
		Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
		gameOverCanvas.SetActive (true);
		Time.timeScale = 0f;
        Cursor.visible = true;
	}
}
