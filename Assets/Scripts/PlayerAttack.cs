using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwnAttack;
    public float startTimeBtwnAttack;

    public Transform attackPos;
    public float attackRange;

    public LayerMask whatIsEnemies;
    public int damage;
    public Animator playerAnim;

    bool attack = false;


    // Update is called once per frame
    void Update()
    {
        if (timeBtwnAttack <= 0)
        { 
            if (Input.GetButtonDown("Attack"))
            {

                playerAnim.SetBool("isAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Whitch>().TakeDamage(damage);
                }
            }

            timeBtwnAttack = startTimeBtwnAttack;
            attack = false;
        }
        else
        {
            timeBtwnAttack -= Time.deltaTime;
            attack = false;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }
}
