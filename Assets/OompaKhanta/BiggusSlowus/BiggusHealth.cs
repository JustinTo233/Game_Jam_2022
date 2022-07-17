using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggusHealth : MonoBehaviour
{
    public float health = 10f;
    public Animator animator;
    public void TakeDamage(float damage)
    {
        animator.ResetTrigger("Shoot");
        animator.SetTrigger("Damaged");
        health -= damage;
        animator.SetFloat("Health", health);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
