using UnityEngine;
using System.Collections;

public class TopDownContrrols : MonoBehaviour {



public float maxSpeed = 10f;
public float rotSpeed = 5f;
Animator anim;
Rigidbody2D rb;
float rot, move;

    public GameObject bullet, muzzle;

void Start () {
   //anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
}
void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        }
    }



void FixedUpdate(){
    rot = Input.GetAxis("Horizontal");
    move = Input.GetAxis("Vertical");
    //anim.SetFloat("Speed",Mathf.Abs(move));
    transform.Rotate(Vector3.forward * -rot * rotSpeed);
    rb.AddRelativeForce(new Vector2(0,move * maxSpeed));
  
}
}
