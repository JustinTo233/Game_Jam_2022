using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggusSlowusShooting : MonoBehaviour
{
#region //public variables
    public Transform firePoint;
    public GameObject laserPrefab;
    public float laserBallForce = 20f;
    public Transform playerCharacter;
    public float fireRate = 1f;
    public float firingRange = 10f;
    public Animator animator;
#endregion

#region //private variables
Rigidbody2D selfRB;
float timeSinceFire = 0f;

#endregion

    // Update is called once per frame
    void Update()
    {
        selfRB = GetComponent<Rigidbody2D>();
    
        //animator.SetFloat("Speedy", Mathf.Abs(selfRB.velocity.y));

        float distance = Vector2.Distance(gameObject.transform.position, playerCharacter.position);
        if ((distance <= firingRange) && (timeSinceFire >= fireRate))
        {
            startShoot();
            timeSinceFire = 0f;
        }
        else
        {
            timeSinceFire += Time.deltaTime;
        }
    }

    void startShoot()
    {
        animator.SetTrigger("Shoot");
    }

    public void Shoot()
    {
        Vector2 playerDirection = playerCharacter.position - firePoint.position;
        playerDirection.Normalize();
        GameObject bullet = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(playerDirection * laserBallForce, ForceMode2D.Impulse);
    }
}
