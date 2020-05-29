using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    
    //public float knockback;
    public float knockTime;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public KeyCode push;

    public float attackRangeX;
    public float attackRangeY;
    

    
    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (!GetComponent<PlayerMovement>().getHold() && Input.GetKey(push))
            {
                print("asdfasdf");
                GetComponent<PlayerMovement>().setFreeze(true);
                StartCoroutine(freezeTime(0.1f));
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY),0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Rigidbody2D enemy = enemiesToDamage[i].GetComponent<Rigidbody2D>();
                    PlayerMovement temp = enemiesToDamage[i].GetComponent<PlayerMovement>();
                    temp.setFreeze(true);
                    //temp.setHold(false);
                    temp.setPush(true);
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized;
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    //print(difference);
                    StartCoroutine(KnockCo(enemy, temp));
                }
                print(enemiesToDamage.Length);
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY));
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

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("ASD");
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            PlayerMovement temp = other.GetComponent<PlayerMovement>();
            if (enemy != null)
            {
                temp.setFreeze(true);
                temp.setPush(true);
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                //print(difference);
                StartCoroutine(KnockCo(enemy, temp));
            }

        }
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

    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY));
    }
    
    
       /* 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                print(difference);
                //StartCoroutine(KnockCo(enemy));
            }
            
        }
    }
    

    */



}
