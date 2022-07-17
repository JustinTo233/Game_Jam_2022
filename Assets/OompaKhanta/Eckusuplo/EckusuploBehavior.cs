using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EckusuploBehavior : MonoBehaviour
{

    public Transform upFrag;
    public Transform rightFrag;
    public Transform leftFrag;
    public Transform downFrag;
    public Transform playerCharacter;
    public GameObject fragPrefab;
    public GameObject explosionEffect;
    public float fragForce = 20f;
    public float explosionDamage = 1f;
    public float explosionRange = 1f;
    public Animator animator;

    void Update()
    {
        //animator.SetFloat("Speedy", Mathf.Abs(selfRB.velocity.y));

        float distance = Vector2.Distance(gameObject.transform.position, playerCharacter.position);
        if ((distance <= explosionRange))
        {
            startExplode();
        }
    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//         /* if (collision.gameObject.CompareTag("Player"))
//         {
//             startExplode();
//         } */
//         startExplode();
//    }

   void startExplode()
   {
        animator.ResetTrigger("Damaged");
        animator.SetTrigger("Explode");
   }

   public void ExplosiveDeath()
   {

        GameObject expEffect = Instantiate(explosionEffect, downFrag.position, Quaternion.identity);
        Destroy(expEffect, 0.5f);

        var hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRange);
        {
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    hitCollider.gameObject.SendMessage("TakeDamage", explosionDamage);
                }
            }
        }

        GameObject upbullet = Instantiate(fragPrefab, upFrag.position, upFrag.rotation);
        Rigidbody2D upbulletRB = upbullet.GetComponent<Rigidbody2D>();
        upbulletRB.AddForce(upFrag.up * fragForce, ForceMode2D.Impulse);

        GameObject rightbullet = Instantiate(fragPrefab, rightFrag.position, rightFrag.rotation);
        Rigidbody2D rightbulletRB = rightbullet.GetComponent<Rigidbody2D>();
        rightbulletRB.AddForce(rightFrag.up * fragForce, ForceMode2D.Impulse);

        GameObject leftbullet = Instantiate(fragPrefab, leftFrag.position, leftFrag.rotation);
        Rigidbody2D leftbulletRB = leftbullet.GetComponent<Rigidbody2D>();
        leftbulletRB.AddForce(leftFrag.up * fragForce, ForceMode2D.Impulse);

        GameObject downbullet = Instantiate(fragPrefab, downFrag.position, downFrag.rotation);
        Rigidbody2D downbulletRB = downbullet.GetComponent<Rigidbody2D>();
        downbulletRB.AddForce(downFrag.up * fragForce, ForceMode2D.Impulse);

        Destroy(gameObject);
   }
}
