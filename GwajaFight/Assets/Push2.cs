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
    RaycastHit2D hit;
    private PlayerMovement moveScript;
    void Start()
    {
        moveScript = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (!GetComponent<PlayerMovement>().getHold() && Input.GetKey(push))
            {
                hit = Physics2D.Raycast(transform.position, new Vector2(moveScript.animator.GetFloat("Horizontal"), moveScript.animator.GetFloat("Vertical")) * transform.localScale.x, 1.3f);
                if(hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    Rigidbody2D enemy = hit.transform.gameObject.GetComponent<Rigidbody2D>();
                    PlayerMovement temp = hit.transform.gameObject.GetComponent<PlayerMovement>();
                    hit.transform.gameObject.GetComponent<PlayerPickupDrop>().holding = false;
                    temp.setFreeze(true);
                    temp.setPush(true);
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized;
                    difference = transformation(difference, GetComponent<PlayerMovement>().getDirection());
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(KnockCo(enemy, temp));
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private Vector2 transformation(Vector2 vec, int check)
    {
        switch (check)
        {
            case 1: //left or right
            case 2:
                vec.y = 0;
                break;
            case 3:
            case 4:
                vec.x = 0;
                break;
        }
        return vec;
    }

    private IEnumerator KnockCo(Rigidbody2D enemy, PlayerMovement other)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
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
