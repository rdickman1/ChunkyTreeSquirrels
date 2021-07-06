using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject Player;

    Vector2 mousePos;

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.LeftShift) && this.enabled==false && Player.GetComponent<PlayerMovement>().enabled == true) 
        {
            this.enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = false;
        } 
        else
        {
            this.enabled = false;
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
