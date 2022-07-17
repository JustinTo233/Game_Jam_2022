using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToLiveBullets = 2f;
    void Start()
    {
         Destroy(gameObject, timeToLiveBullets);;
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
    if(collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemyComponenet))
    {
        enemyComponenet.TakeDamage(1);
    }
    Destroy(gameObject);
   }
}
