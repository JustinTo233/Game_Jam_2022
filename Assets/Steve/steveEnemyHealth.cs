using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steveEnemyHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 50f;

    private void Start(){
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
         } 
    }

}
