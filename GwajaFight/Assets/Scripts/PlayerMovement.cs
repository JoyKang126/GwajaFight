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
    public Animator animator;
    Vector2 movement;

    private bool freezeStatus = false;
    private bool holdStatus = false;
    private bool pushStatus = false;

    public int totalPoints = 0;

    // Update is called once per frame
    void Update()
    {
        //Input
        if (!freezeStatus)
        {
            if (Input.GetKey(left))
            {
                movement.x = -1;
                movement.y = 0;
            }
            else if (Input.GetKey(right))
            {
                movement.x = 1;
                movement.y = 0;
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

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //Movement
        if (!freezeStatus)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void setFreeze(bool check)
    {
        freezeStatus = check;
    }

    public void setPush(bool check)
    {
        pushStatus = check;
    }

    public void setHold(bool check)
    {
        holdStatus = check;
    }

    public bool getFreeze()
    {
        return freezeStatus;
    }

    public bool getPush()
    {
        return pushStatus;
    }

    public bool getHold()
    {
        return holdStatus;
    }

    public int getDirection()
    {
        if (this.animator.GetFloat("Horizontal") == -1) //facing left
            return 1;
        else if (this.animator.GetFloat("Horizontal") == 1)//facing right
            return 2;
        else if (this.animator.GetFloat("Vertical") == -1)//facing down
            return 3;
        else                                              //facing up
            return 4;
    }

    public int getScore()
    {
        return totalPoints;
    }

    public void addScore(int points)
    {
        totalPoints += points;
    }

}
