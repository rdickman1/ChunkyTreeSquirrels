using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehavior : MonoBehaviour
{

    public Player player;

    int healthUpgradeAmount = 20;
    int gunUpgradeAmount;
    int shieldUpgradeAmount;
    int meleeUpgradeAmount;

   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Gun Upgrade
        if(collider.transform.tag == "Gun Upgrade")
        {
            //Run into upgrade

            //Upgrade weapons

            //Destroy Upgrade object
            Destroy(collider.gameObject);
        }

        //Shield Upgrade
        if (collider.transform.tag == "Shield Upgrade")
        {
            //Run into upgrade

            //Upgrade Shield

            //Destroy Upgrade object
            Destroy(collider.gameObject);
        }

        //Melee Upgrade
        if (collider.transform.tag == "Melee Upgrade")
        {
            //Run into upgrade

            //Upgrade melee weapon

            //Destroy Upgrade object
            Destroy(collider.gameObject);
        }

        //Health Upgrade
        if (collider.transform.tag == "Health Upgrade")
        {
            //Run into upgrade

            //Upgrade health
            player.UpgradeHealth(healthUpgradeAmount);

            //Destroy Upgrade object
            Destroy(collider.gameObject);
        }
    }

    
}
