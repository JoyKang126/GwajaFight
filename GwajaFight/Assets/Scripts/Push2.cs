using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push2 : MonoBehaviour
{
    public KeyCode push;
    public float knockTime;
    public Transform attackPos;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float stunTime;
    RaycastHit2D hit;
    private PlayerMovement moveScript;
    void Start()
    {
        moveScript = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(push) && timeBtwAttack <= 0)
        {
            if (!GetComponent<PlayerMovement>().getHold())
            {
                StartCoroutine(AttackCo());
                Debug.Log("hit");
                hit = Physics2D.Raycast(transform.position, new Vector2(moveScript.animator.GetFloat("Horizontal"), moveScript.animator.GetFloat("Vertical")) * transform.localScale.x, 1.3f);
                if(hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    Rigidbody2D enemy = hit.transform.gameObject.GetComponent<Rigidbody2D>();
                    PlayerMovement temp = hit.transform.gameObject.GetComponent<PlayerMovement>();
                    hit.transform.gameObject.GetComponent<PlayerPickupDrop>().setInteractable();
                    hit.transform.gameObject.GetComponent<PlayerPickupDrop>().holding = false;
                    //set the holding in playermovement to false for the other player
                    print("ASD");
                    temp.animator.SetBool("Pushed", true);
                    temp.setFreeze(true);
                    temp.setPush(true);
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized;
                    difference = transformation(difference, GetComponent<PlayerMovement>().getDirection());
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(KnockCo(enemy, temp));
                    //StartCoroutine(PushedCo(temp));
                }
            }
            timeBtwAttack = startTimeBtwAttack + Time.deltaTime;
        }
        else if (timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }           
    }

    private Vector2 transformation(Vector2 vec, int check)
    {
        switch (check)
        {
            case 1: //left or right
                vec.y = 0;
                vec.x = -10;
                break;
            case 2:
                vec.y = 0;
                vec.x = 10;
                break;
            case 3: //up or down
                vec.x = 0;
                vec.y = -10;
                break;
            case 4:
                vec.x = 0;
                vec.y = 10;
                break;
        }
        return vec;
    }

    private IEnumerator AttackCo()
    {
        moveScript.animator.SetBool("Pushing", true);
        yield return null;
        moveScript.animator.SetBool("Pushing", false);
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator PushedCo(PlayerMovement other)
    {
        other.animator.SetBool("Pushed", true);
        yield return null;
        other.animator.SetBool("Pushed", false);
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator KnockCo(Rigidbody2D enemy, PlayerMovement other)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            yield return new WaitForSeconds(stunTime);
            other.animator.SetBool("Pushed", false);
        }
        other.setFreeze(false);
        other.setPush(false);
    }

    private IEnumerator freezeTime(float f)
    {
        yield return new WaitForSeconds(f);
        GetComponent<PlayerMovement>().setFreeze(false);
    }
}
