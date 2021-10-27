using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //Enemy Movement Speed
    public float moveSpeed;
    
    //The target which the enemies move towards
    public Transform target;
    
    //Animator for the enemies
    private Animator anim;

    //Rigibody for the enemies
    Rigidbody2D enemyrigidbody;

    //A bool which is used to change animation state
    private bool enemyMoving;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<HealthBarScript>().health -= 10f;
        }
    }

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //The target is the player
        anim = GetComponent<Animator>(); 
        enemyrigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); 

        //Animation so that the enemy changes animation when moving a direction
        if (enemyrigidbody.velocity.y > 0.5 || enemyrigidbody.velocity.y < -0.5 || enemyrigidbody.velocity.x > 0.5 || enemyrigidbody.velocity.x < -0.5) // if the enemy is moving faster than 0.5f or -0.5f on the x or y axis
        {
            anim.SetBool("enemyMoving", true); //set this bool to true
            anim.SetBool("enemyAttack", false); //set this bool to false
        }
        else if (enemyrigidbody.velocity.y < 0.5 || enemyrigidbody.velocity.y > -0.5 || enemyrigidbody.velocity.x < 0.5 || enemyrigidbody.velocity.x > -0.5) // if the enemy is moving slower than 0.5f or -0.5f on the x or y axis
        {
            anim.SetBool("enemyMoving", false); //set this bool to false
            anim.SetBool("enemyAttack", true); //set this bool to true
        }
    }
}
