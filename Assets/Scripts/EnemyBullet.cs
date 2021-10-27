using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float speed;
	private Transform player;
	private Vector2 target;


	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Gate").transform;
		target = new Vector2 (player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);

		if (transform.position.x == target.x && transform.position.y == target.y) 
		{
			DestroyArrow ();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Gate")) 
		{
			GateHealthBar e = other.transform.GetComponent<GateHealthBar> ();
			if (e != null) {
				e.health -= 5f; 
			}
			DestroyArrow ();
		}
	}
		
		
	void DestroyArrow()
	{
		Destroy(gameObject);
	}
	
}
