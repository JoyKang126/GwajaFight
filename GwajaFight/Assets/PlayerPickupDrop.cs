using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour
{
    //Controls
    public KeyCode pickupdrop;
    public bool holding = false;
    public Transform holdpoint;
    RaycastHit2D hit;
    public GameObject currentInterObj = null;
    // Start is called before the first frame update
    private PlayerMovement moveScript;

    private Vector3 originalPosition;
    void Start()
    {
        moveScript = GetComponent<PlayerMovement>();
    }
/*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("interactable"))
        {
            currentInterObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interactable") && !holding)
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
    }
*/
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pickupdrop))
        {
            //Physics2D.queriesStartInColliders = false;
            if (!holding)
            {
                if (moveScript.animator.GetFloat("Horizontal") == 0) //facing up or down
                    hit = Physics2D.Raycast(transform.position, new Vector2(moveScript.animator.GetFloat("Horizontal"),moveScript.animator.GetFloat("Vertical"))* transform.localScale.x, 1f);
                else if (moveScript.animator.GetFloat("Vertical") == 0) //facing left or right
                    hit = Physics2D.Raycast(transform.position, new Vector2(moveScript.animator.GetFloat("Horizontal"),moveScript.animator.GetFloat("Vertical"))* transform.localScale.x, 0.5f);

                if (hit.collider!=null && hit.collider.CompareTag("interactable"))
                {
                    StartCoroutine(PickupDropCo());
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "SnackHeld";
                    GetComponent<PlayerMovement>().setHold(true);
                    holding = true;
                    hit.collider.gameObject.tag = "noninteractable";
                }
            }
            else if (holding)
            {
                StartCoroutine(PickupDropCo());
                hit.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Snack";
                GetComponent<PlayerMovement>().setHold(false);
                holding = false;
                hit.collider.gameObject.tag = "interactable";
            }
        }
        if(holding)
        {
            //find out what direction we're facing
            if (moveScript.animator.GetFloat("Horizontal") == -1) // facing left
                hit.collider.gameObject.transform.position = holdpoint.position + new Vector3(moveScript.animator.GetFloat("Horizontal") +(float)0.5, moveScript.animator.GetFloat("Vertical"),0);
            if (moveScript.animator.GetFloat("Horizontal") == 1) //facing right
                hit.collider.gameObject.transform.position = holdpoint.position + new Vector3(moveScript.animator.GetFloat("Horizontal") - (float)0.5, moveScript.animator.GetFloat("Vertical"), 0);
            if(moveScript.animator.GetFloat("Vertical") == -1) //facing down
                hit.collider.gameObject.transform.position = holdpoint.position + new Vector3(moveScript.animator.GetFloat("Horizontal"), moveScript.animator.GetFloat("Vertical"), 0);
            if (moveScript.animator.GetFloat("Vertical") == 1) //facing up
                hit.collider.gameObject.transform.position = holdpoint.position + new Vector3(moveScript.animator.GetFloat("Horizontal"), moveScript.animator.GetFloat("Vertical") + (float)0.2, 0);
        }
    }

    private IEnumerator PickupDropCo()
    {
        moveScript.animator.SetBool("PickingUp", true);
        yield return null;
        moveScript.animator.SetBool("PickingUp", false);
        yield return new WaitForSeconds(0.5f);
    }
    public void moveSnack()
    {
        originalPosition = hit.collider.gameObject.transform.position;
        hit.collider.gameObject.transform.position = holdpoint.position;
    }

    public void returnSnack()
    {
        hit.collider.gameObject.transform.position = originalPosition;
    }

    public void eat()
    {
        GetComponent<PlayerMovement>().setHold(false);
        holding = false;
        GetComponent<PointsScript>().addScore(hit.collider.gameObject.GetComponent<Snack>().getPointValue());
        Debug.Log(GetComponent<PointsScript>().getScore());
        Destroy(hit.collider.gameObject);
        hit = new RaycastHit2D();
    }

    public void setInteractable()
    {
        if (holding)
        {
            hit.collider.gameObject.tag = "interactable";
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
       // Gizmos.DrawLine(transform.position, transform.position+moveScript.getMovement()*transform.localScale.x*2f);
    }
    
}
