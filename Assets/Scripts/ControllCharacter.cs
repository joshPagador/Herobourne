using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllCharacter : MonoBehaviour {


    public float speed = 5, arrowCooldown;
    enum PlayerDirection { N,NE,E,SE,S,SW,W,NW};
    PlayerDirection currentDirection, newDirection;
    Rigidbody2D rb;
    bool moving;
    Vector2 moveVec;
    public GameObject arrow;
	public GameObject arrowUpgrade;
    float rot, coolDown;
	public GameObject arrowUpgadeActive;
	public GameObject arrowUpgradeDeactive;


	// Use this for initialization
	void Start () {
        currentDirection = PlayerDirection.N;
        rb = GetComponent<Rigidbody2D>();

	}
		
    private void FixedUpdate()
    {
        moveVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = moveVec.normalized*speed;
    }

    // Update is called once per frame
    void Update () {

    
        if (Input.GetKey(KeyCode.W))
        {
     
            if (Input.GetKey(KeyCode.A))
            {
                newDirection = PlayerDirection.NW;
            }else if (Input.GetKey(KeyCode.D))
            {
                newDirection = PlayerDirection.NE;
            }
            else
            {
                newDirection = PlayerDirection.N;
            }
        }else if (Input.GetKey(KeyCode.S))
        {
            moving = true;
            if (Input.GetKey(KeyCode.A))
            {
                newDirection = PlayerDirection.SW;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                newDirection = PlayerDirection.SE;
            }
            else
            {
                newDirection = PlayerDirection.S;
            }
        }else if (Input.GetKey(KeyCode.A))
        {
            moving = true;
            newDirection = PlayerDirection.W;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving = true;
            newDirection = PlayerDirection.E;
        }
        if (newDirection != currentDirection)
        {
            currentDirection = newDirection;
            switch (currentDirection)
            {
                case PlayerDirection.N:
                case PlayerDirection.NE:
                case PlayerDirection.NW:
         
                    break;
                case PlayerDirection.S:
                case PlayerDirection.SE:
                case PlayerDirection.SW:
                   
                    break;
                case PlayerDirection.E:
                 
                    break;
                case PlayerDirection.W:
         
                    break;
            }
            
        }

        if (Input.GetButtonDown("Fire1") & coolDown > arrowCooldown) 
        {
			if (GameObject.FindGameObjectWithTag ("Player").GetComponent<HighScore> ().score >= 150) 
				//upgrade system (gets score and then instantiates the specified arrow)
			{
				arrowUpgadeActive.SetActive (true);
				arrowUpgradeDeactive.SetActive (false);
				arrowCooldown = 0.5f;
				GameObject upgradeArrow = Instantiate (arrowUpgrade);

				switch (currentDirection) {
				case PlayerDirection.S:
					rot = 180;
					break;
				case PlayerDirection.SE:
					rot = -135;
					break;
				case PlayerDirection.SW:
					rot = 135;
					break;
				case PlayerDirection.N:
					rot = 0;
					break;
				case PlayerDirection.NE:
					rot = -45;
					break;
				case PlayerDirection.NW:
					rot = 45;
					break;
				case PlayerDirection.E:
					rot = -90;
					break;
				case PlayerDirection.W:
					rot = 90;
					break;
				}
				upgradeArrow.transform.position = transform.position;
				upgradeArrow.transform.Rotate (0, 0, rot);
				upgradeArrow.transform.Translate (0, 2, 0);
				coolDown = 0f;
			}
				else {
				arrowUpgadeActive.SetActive (false);
				arrowUpgradeDeactive.SetActive (true);
				arrowCooldown = 0f;
				GameObject newArrow = Instantiate (arrow);

				switch (currentDirection) {
				case PlayerDirection.S:
					rot = 180;
					break;
				case PlayerDirection.SE:
					rot = -135;
					break;
				case PlayerDirection.SW:
					rot = 135;
					break;
				case PlayerDirection.N:
					rot = 0;
					break;
				case PlayerDirection.NE:
					rot = -45;
					break;
				case PlayerDirection.NW:
					rot = 45;
					break;
				case PlayerDirection.E:
					rot = -90;
					break;
				case PlayerDirection.W:
					rot = 90;
					break;
				}

				newArrow.transform.position = transform.position;
				newArrow.transform.Rotate (0, 0, rot);
				newArrow.transform.Translate (0, 2, 0);
				coolDown = 0f;

			}
        }
        coolDown += Time.deltaTime;
    }
}
