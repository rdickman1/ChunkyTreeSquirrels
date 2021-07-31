using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Transform findNearestWithTag(GameObject caller, string objTag)
    {
        GameObject[] objectsInScene;
        Transform callerTransform = caller.GetComponent<Transform>();
        Transform nearestWithTag = null;  

        //TODO add ship tag special search
        /*if(objTag == "Ship")
        {
            
        }*/

        objectsInScene = GameObject.FindGameObjectsWithTag(objTag);

        if(objectsInScene == null || objectsInScene.Length == 0) //if no objects with tag are found
        {
            return null;
        }

        float distance = Mathf.Infinity;
        foreach(GameObject objectInScene in objectsInScene)
        {   //finds the closest game object with the given tag
            float tempDistance = Mathf.Abs(Vector2.Distance(callerTransform.position, objectInScene.transform.position));
            if(tempDistance < distance)
            {
                distance = tempDistance;
                nearestWithTag = objectInScene.transform; 
            }
        }
        return nearestWithTag;
    }
}
