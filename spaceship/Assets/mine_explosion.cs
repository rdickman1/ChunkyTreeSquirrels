using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine_explosion : MonoBehaviour
{
    public GameObject on_Hit;   //animation 
    bool exploded = false;
    /* If ship collides with mine, mine explodes */
    private void OnTriggerEnter2D( Collider2D collider ) {
        if( collider.transform.tag == "Ship" && !exploded ){ 
            collider.GetComponent<Player>().TakeDamage(15); //player takes damage
            exploded = true;   

            explodeMine();
            
            //disable sprite renderer to show explosion
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            
            Destroy( gameObject, 3f );
        }
    }

    /*  Function to spawn explosion animation, scale it relative to the mines scale, 
        and destroy the animation once completed */
    private void explodeMine(){
        GameObject effect = Instantiate(on_Hit, transform.position, Quaternion.identity);
        effect.transform.localScale += transform.lossyScale;
        Destroy( on_Hit, 3f );
    }



}


