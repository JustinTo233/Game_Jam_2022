using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BiggusSlowusGFX : MonoBehaviour
{
    public AIPath aiPath;
    public float sprite_offset = 7.03f;
    public Animator animator;
    public BiggusSlowusShooting bss;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.localPosition = new Vector3(sprite_offset, 0f, 0f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.localPosition = new Vector3(0f - sprite_offset, 0f, 0f);
        }

        animator.SetFloat("Speed", aiPath.desiredVelocity.magnitude);
    }

    void shoot_funct()
    {
        bss.Shoot();
    }
}
