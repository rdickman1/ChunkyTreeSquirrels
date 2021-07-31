using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    #region Attributes
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 400f;

    public float bulletSpawnDistance = .5f;

    public float fireRate = .3f;
    public float nextFire = 0f;


    #endregion

    #region Monobehaviour API
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            
        }
    }

    #endregion

    #region Shoot
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce);
       
    }


    #endregion

}
