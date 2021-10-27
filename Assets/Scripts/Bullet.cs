using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 5;
	public float damage = 10f;

	void Update () {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
		Destroy(gameObject, 5f);
 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
			//This line of code specify which enemy health bar is to be deducted on collision
			EnemyHBscript e = other.transform.GetComponent<EnemyHBscript> ();
			if(e != null)
				e.health -= damage; 
            Destroy(gameObject);
        }

    }


}
