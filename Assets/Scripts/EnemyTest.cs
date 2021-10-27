using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {

	public float speed;
	public Transform target;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			FindObjectOfType<HealthBarScript> ().health -= 10f;
		}

	}

	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
	}

}
