using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHBscript : MonoBehaviour
{
	
    public Image healthBar;

    public float maxHealth = 100f;

	public float health;

	public int point = 10;

    // Use this for initialization
    void Start()
    {
        
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (healthBar.fillAmount == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HighScore>().UpdateScore(point);
			Destroy(this.gameObject);
        }
    }
}
