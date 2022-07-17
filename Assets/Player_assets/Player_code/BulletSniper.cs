using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSniper : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit");
            collision.gameObject.SendMessage("TakeDamage", bullet_damage);
            BulletDestroy();
        }
    }
}
