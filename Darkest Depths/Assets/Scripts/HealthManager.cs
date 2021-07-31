using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float dropChance = 0.5f;
    public int numPowerUps = 4;
    public GameObject pow1;
    public GameObject pow2;
    public GameObject pow3;
    public GameObject pow4;
    public float health = 100.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0.0f)
        {
            var drop = Random.Range(0f, 1f);
            float noSpawnChance = (1 - dropChance);
            if( drop < noSpawnChance ){
                //do nothing, no item drop
            } 
            else if(drop < (noSpawnChance + (dropChance/numPowerUps) )){
                Instantiate(pow1, transform.position, Quaternion.identity);
            }
            else if(drop < (noSpawnChance + 2*(dropChance/numPowerUps) )){
                Instantiate(pow2, transform.position, Quaternion.identity);
            }
            else if(drop < (noSpawnChance + 3*(dropChance/numPowerUps) )){
                Instantiate(pow3, transform.position, Quaternion.identity);
            }
            else if(drop < (noSpawnChance + 4*(dropChance/numPowerUps) )){
                Instantiate(pow4, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
