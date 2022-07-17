using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletDamage = 1f;
   void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.gameObject.SendMessage("TakeDamage", bulletDamage);
    }
    Destroy(gameObject);
   }
}
