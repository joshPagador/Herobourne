using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemy2 : MonoBehaviour {

	public float speed;
	public float stoppingDistance;
	public float retreatDistance;

	private float timeBetweenShots;
	public float startTimeBetweenShots;

	public GameObject arrow;
	public Transform Player;


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;

		timeBetweenShots = startTimeBetweenShots;
	}

	// Update is called once per frame
	void Update () {

		if (Vector2.Distance (transform.position, Player.position) > stoppingDistance) 
		{
			transform.position = Vector2.MoveTowards (transform.position, Player.position, speed * Time.deltaTime);
		} 
		else if (Vector2.Distance (transform.position, Player.position) < stoppingDistance && Vector2.Distance (transform.position, Player.position) > retreatDistance) 
		{
			transform.position = this.transform.position;
		}
		else if(Vector2.Distance(transform.position, Player.position) < retreatDistance)
		{
			transform.position = Vector2.MoveTowards (transform.position, Player.position, -speed * Time.deltaTime);
		}


		if (timeBetweenShots <= 0) 
		{
			Instantiate (arrow, transform.position, Quaternion.identity);
			timeBetweenShots = startTimeBetweenShots;
		} 
		else 
		{
			timeBetweenShots -= Time.deltaTime;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			FindObjectOfType<HealthBarScript> ().health -= 10f;
		}

	}
}
