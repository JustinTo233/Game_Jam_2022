using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    // public int currentHealth = 1;
    private void Start() 
    {
        health = maxHealth;
    }
    // take damage
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            
            Destroy(gameObject);
         } 
    }

    // attack

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                // other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                if(other.gameObject.CompareTag("Player"))
                {
                    other.gameObject.SendMessage("TakeDamage", attackDamage);
                }
                canAttack = 0f;
            } else{
                canAttack += Time.deltaTime;
            }
        }
    }
}
