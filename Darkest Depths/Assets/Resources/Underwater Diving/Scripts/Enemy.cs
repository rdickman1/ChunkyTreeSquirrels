using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

public class Enemy : MonoBehaviour {

	private GameObject player;
	public Vector3 towardsPlayer;
	public AIPath seekerAI;
	public GameObject death;
	public int dmgTakenInc;

	[Header("Health")]

	[SerializeField] private float health;
	public float maxHealth = 100;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Ship");
		health = maxHealth;
	}

	// Update is called once per frame
	void Update (){
		towardsPlayer = player.transform.position - transform.position;
		if(seekerAI.hasPath){
			if(seekerAI.desiredVelocity.x > 0){
				turnAround(0);
			}
			else if(seekerAI.desiredVelocity.x < 0){
				turnAround(1);
			}
		}


	}


	void OnTriggerEnter2D(Collider2D other){

	}

	void turnAround(int dir){
		if (dir == 1) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else {
			transform.localScale = new Vector3 (1f,1f,1f);
		}
	}

	public void TakeDamage(float damage)
    {
		health = health - damage - dmgTakenInc;

		if (health <= 0)
        {
			Destroy(gameObject);
        }
    }
}
