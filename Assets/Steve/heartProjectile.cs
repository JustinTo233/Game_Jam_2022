using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartProjectile : MonoBehaviour
{
    public float heartLifespan = 3.0f;
    public float emotionalDamage = 1f;
    void Start()
    {
         Destroy(gameObject, heartLifespan);;
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", emotionalDamage);
        }
        Destroy(gameObject);
    }
}
