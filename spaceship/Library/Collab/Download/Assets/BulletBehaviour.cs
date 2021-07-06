using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    #region Attributes
    public float unitsPerSecond = 1;

    public float lifetime = 4;

    public GameObject hitEffect;
    public GameObject tileMap;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardDirection = transform.InverseTransformDirection(transform.up);
        transform.Translate(forwardDirection * unitsPerSecond * Time.deltaTime);
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
