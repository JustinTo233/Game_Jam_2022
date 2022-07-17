using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : GunScript
{
    // Start is called before the first frame update

    void Start()
    {
        weapon_cooldown = 0;
        tf = GetComponent<Transform>();
        Debug.Log(GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        AttackCheck();
        GunDirection();
    }
}
