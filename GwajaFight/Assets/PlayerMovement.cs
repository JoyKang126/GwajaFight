using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Controls
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    // Public variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        //Input
        if (Input.GetKey(left))
        {
            movement.x = -1;
            movement.y=0;
        }
        else if (Input.GetKey(right))
        {
            movement.x = 1;
            movement.y=0;
        }
        else
        {
            movement.x = 0;
        }
            

        if (Input.GetKey(up))
        {
            movement.y = 1;
            movement.x = 0;
        }
            
        else if (Input.GetKey(down))
        {
            movement.y = -1;
            movement.x = 0;
        }  
        else
        {
            movement.y = 0;
        }
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
