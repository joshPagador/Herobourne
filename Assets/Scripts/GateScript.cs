using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") 
		{
			FindObjectOfType<GateHealthBar> ().health -= 10f;
		}

	}
}
