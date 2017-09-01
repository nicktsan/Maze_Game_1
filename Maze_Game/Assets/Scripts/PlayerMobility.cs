using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //Get up, down, left, right input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        //player movespeed
        rb.velocity = movement * speed;

        //make player sprite face mouse cursor
        /*
        Vector3 player_pos = Camera.main.WorldToScreenPoint(transform.position);
        
        Vector3 difference = Input.mousePosition - player_pos;
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Subtract 90 from the rotation, or else the sprite will face +90 degrees in regards to the mouse cursor.
        transform.rotation = Quaternion.AngleAxis(rotation_z - 90, Vector3.forward);
        */

        //make player sprite face moving direction
        Vector2 moveDirection = rb.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            if (Mathf.Abs(angle) < 90)
            {
                transform.rotation = Quaternion.AngleAxis(0 - 90, Vector3.forward);
            }
            else if (Mathf.Abs(angle) > 90)
            {
                transform.rotation = Quaternion.AngleAxis(180 - 90, Vector3.forward);
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            }
        }
        rb.angularVelocity = 0;
    }
}
