using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehavior : MonoBehaviour
{

    public Player player;
    public MeleeCooldown melee;
    int healthUpgradeAmount = 100;
    int gunUpgradeAmount;
    int shieldUpgradeAmount = 20;
    int meleeUpgradeAmount;

   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Gun Upgrade
        if(collider.transform.tag == "Gun Upgrade")
        {
            
            //Run into upgrade

            //Upgrade weapons
            foreach (Transform child in transform) {
                if (child.tag == "Weapon")
                {
                    child.GetComponent<ShipWeapon>().fireRate -= .07f;
                    child.GetComponent<ShipWeapon>().bulletForce += 100f;
                }
            }
            //Destroy Upgrade object
            Destroy(collider.gameObject);
        }

        //Shield Upgrade
        if (collider.transform.tag == "Shield Upgrade")
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            player.UpgradeShield(shieldUpgradeAmount);
            //Upgrade Shield

            //Destroy Upgrade object
            Destroy(collider.gameObject);
        }

        //Melee Upgrade
        if (collider.transform.tag == "Melee Upgrade")
        {
            gameObject.transform.GetChild(4).gameObject.GetComponent<Melee>().damage += 5;
            
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
