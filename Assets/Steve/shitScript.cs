using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitScript : MonoBehaviour
{
    public float shitDamage = 0.5f;
    public float shitShelflife = 3.0f;
    void Start()
    {
         Destroy(gameObject, shitShelflife);;
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", shitDamage);
        }
        Destroy(gameObject);
    }
}

