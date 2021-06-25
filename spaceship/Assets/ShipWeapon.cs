using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    #region Attributes
    public GameObject bulletPrefab;

    public float bulletSpawnDistance = .5f;

    #endregion

    #region Monobehaviour API
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet(transform.up * bulletSpawnDistance + transform.position, transform.rotation);
        }
    }

    #endregion
    private void FireBullet(Vector3 position, Quaternion rotation)
    {
        Instantiate(bulletPrefab, position, rotation);
    }

}
