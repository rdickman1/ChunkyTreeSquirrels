using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	private GameObject player;

	//var to handle attack cooldown
	private int canAttack = 1;	
	//var to handle consumer producer problem 
	private bool forceWaiting = false;
	
	public int playerDamage = 10;
	public float recoilForce = 100; 
	public float attackCooldown = 2f;

	private Vector2 forceVector;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Ship");
		rb = (Rigidbody2D)gameObject.GetComponent(typeof(Rigidbody2D));
	}

	void FixedUpdate(){
		
		if(forceWaiting){
			forceWaiting = false;
			rb.AddForce(forceVector, ForceMode2D.Force);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.transform.tag == "Ship" && canAttack > 0){
			--canAttack;
			player.GetComponent<Player>().TakeDamage(playerDamage);	 
			Invoke("AllowAttack", attackCooldown);

			Transform playerPosition = player.GetComponent<Transform>();
			RecoilOnAttack(playerPosition);
		}

	}

	private void RecoilOnAttack(Transform playerPosition){
		Vector2 towardsPlayer = playerPosition.position - rb.transform.position;
		forceVector = towardsPlayer * -1 * recoilForce * Time.deltaTime;
		forceWaiting = true;
	}

	//function that enables enemy attack. Attacking is temporarily disabled after hurting player
	private void AllowAttack(){
		canAttack++;
	}



}

