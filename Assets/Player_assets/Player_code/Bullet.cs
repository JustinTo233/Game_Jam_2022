using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_damage; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ADD TAGS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            collision.gameObject.SendMessage("TakeDamage", bullet_damage);
            BulletDestroy();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit");
            BulletDestroy();
        }
    }

    private void BulletDestroy()
    {
        Destroy(this.gameObject, 0);
    }
    
}
