using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject player;
    public float speed = 720f;
    public Vector3 direction = Vector3.up;
    public int damage = 20;
    public GameObject hitEffect;
    
  
    
    void Update()
    {
        transform.RotateAround(player.transform.position, direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            HealthManager enemy = collider.gameObject.GetComponent<HealthManager>();
            enemy.TakeDamage(damage);
        }
        if (collider.tag == "Ship")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Player player = collider.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }

}
