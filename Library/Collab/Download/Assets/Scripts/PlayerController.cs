using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D myrigidbody;
    private bool playerMoving;
    private Vector2 lastMove;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        playerMoving = false;

        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            myrigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal")* moveSpeed, myrigidbody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, Input.GetAxisRaw("Vertical")* moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myrigidbody.velocity = new Vector2(0f, myrigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
