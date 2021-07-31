using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    private Vector3 zAngle;
    public float angle;
    public GameObject player;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        /*(if (angle < 90 && player.transform.eulerAngles.z < 90 && angle > 0 && player.transform.eulerAngles.z > 0 && angle - player.transform.eulerAngles.z > 20)
        {
            angle = player.transform.eulerAngles.z + 20;
        } 
        else if (angle < 90 && player.transform.eulerAngles.z < 90 && angle > 0 && player.transform.eulerAngles.z > 0 && player.transform.eulerAngles.z - angle > 20)
        {
            angle = player.transform.eulerAngles.z - 20;
        } */
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    /*private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }*/
}
