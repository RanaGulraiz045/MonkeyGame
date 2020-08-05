using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCombat : MonoBehaviour
{
    public int attackDamage = 40;
    public Animator animationAttack;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;


    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Attack"))
        {
            Attack();
        }
    }
    void Attack()
    {
        animationAttack.SetTrigger("Attack");
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in enemyHit)
        {
            Debug.Log("Yes");
            enemy.GetComponent<StoneSkullDamage>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
