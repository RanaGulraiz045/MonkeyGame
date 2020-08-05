using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSkullDamage : MonoBehaviour
{
    public GameObject stoneSkull;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Yeah");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
   
   void Die()
    {
        Destroy(stoneSkull);
    }

}
