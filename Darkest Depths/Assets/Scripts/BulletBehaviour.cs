using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    #region Attributes

    public float unitsPerSecond = 1;

    public float lifetime = 4;

    public Transform bulletPrefab;
    public GameObject hitEffect;
    public int bulletDamage = 5;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifetime);
    }

    private void OnEnable()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        foreach (GameObject obj in bullets)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }        
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 forwardDirection = transform.InverseTransformDirection(transform.up);
        transform.Translate(forwardDirection * unitsPerSecond * Time.deltaTime);
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
            HealthManager enemy = collision.gameObject.GetComponent<HealthManager>();
            enemy.TakeDamage(bulletDamage);
        }
        if (collision.gameObject.tag == "Ship")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(bulletDamage);

        }
        if (collision.gameObject.tag == "Tilemap")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

}
