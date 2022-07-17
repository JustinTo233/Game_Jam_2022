using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitAttack : MonoBehaviour
{
    public GameObject shitPrefab;
    public Transform firePoint;
    public float fireForce = 0.0f;
    public float shitCooldownCurr = 0.0f;
    public float shitCooldownEnd = 3.0f;

    public void SHIT()
    {
        GameObject shitpile = Instantiate(shitPrefab, firePoint.position, firePoint.rotation);

    }

    void Start(){

    }
    void FixedUpdate(){
        if(shitCooldownCurr >= shitCooldownEnd) {
            SHIT();
            shitCooldownCurr = 0.0f;
        }
        else {
            Debug.Log("prepping for a shit");
            shitCooldownCurr += Time.deltaTime;
        }
    }
}
