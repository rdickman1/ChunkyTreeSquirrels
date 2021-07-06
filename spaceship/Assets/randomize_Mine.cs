using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomize_Mine : MonoBehaviour
{
    Vector3 scaleVector;
    public float scaleMin = 1.8f;
    public float scaleMax = 4.5f;

    void start()
    {
        float randomScale = Random.Range( scaleMin, scaleMax );
        scaleVector.Set( randomScale, randomScale, randomScale );

        transform.localScale = scaleVector;
        transform.rotation = Random.rotation;
    }
}
