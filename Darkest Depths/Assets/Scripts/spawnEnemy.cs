using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 2f, spawnRate);

    }

    private void Spawner()
    {
        Transform nearestPlayer = Utility.findNearestWithTag(gameObject, "Ship");
    }

}
