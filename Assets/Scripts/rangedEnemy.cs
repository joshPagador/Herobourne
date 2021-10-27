using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemy : MonoBehaviour {

	public float speed;
	public float stoppingDistance;
	public float retreatDistance;

	private float timeBetweenShots;
	public float shootCooldown;

	public GameObject arrow;
	public Transform gate;


	// Use this for initialization
	void Start () {
		gate = GameObject.FindGameObjectWithTag ("Gate").transform;

		timeBetweenShots = shootCooldown;
	}

	// Update is called once per frame
	void Update () {

		if (Vector2.Distance (transform.position, gate.position) > stoppingDistance) 
		{
			transform.position = Vector2.MoveTowards (transform.position, gate.position, speed * Time.deltaTime);
		} 
		else if (Vector2.Distance (transform.position, gate.position) < stoppingDistance && Vector2.Distance (transform.position, gate.position) > retreatDistance) 
		{
			transform.position = this.transform.position;
		}
		else if(Vector2.Distance(transform.position, gate.position) < retreatDistance)
		{
			transform.position = Vector2.MoveTowards (transform.position, gate.position, -speed * Time.deltaTime);
		}


		if (timeBetweenShots <= 0) 
		{
			Instantiate (arrow, transform.position, Quaternion.identity);
			timeBetweenShots = shootCooldown;
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
