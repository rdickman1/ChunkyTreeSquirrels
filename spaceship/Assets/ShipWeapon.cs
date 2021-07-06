using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    #region Attributes
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float bulletSpawnDistance = .5f;

    #endregion

    #region Monobehaviour API
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    #endregion

    #region Shoot
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
       
    }


    #endregion

}
