using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EckusuploGFX : MonoBehaviour
{

        public AIPath aiPath;
        public Animator animator;
        public float sprite_offset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }
}
