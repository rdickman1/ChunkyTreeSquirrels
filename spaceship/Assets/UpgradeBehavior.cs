using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehavior : MonoBehaviour
{

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.tag == "Upgrade")
        {
            //Run into upgrade
            Destroy(collider.gameObject);
        }
    }

    
}
