using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera cam;
    public GameObject Weapon1;
    public GameObject Weapon2;
    Vector2 mousePos;
    public Vector2 lookDir;
    public float maxVelocity = 12;
    public float accRate = 1f;
    float playerSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       // if (photonView.IsMine)
       // {
            TakeInput();
       // }

    }

    private void TakeInput()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        playerSpeed = rb.velocity.sqrMagnitude;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        ThrustForward(yAxis);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void ThrustForward (float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);

        if (playerSpeed > maxVelocity)
        {
            rb.velocity = Vector3.Normalize(rb.velocity) * Mathf.Sqrt(maxVelocity);
        }

    }

    private void FixedUpdate()
    {

       // if (photonView.IsMine)
       // {
            MouseInput();
       // }
        

    }

    private void MouseInput()
    {
        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), accRate * Time.deltaTime);
    }
}
