using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyuKyuBeam : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform firePoint;
    public float fireForce = 50.0f;
    public float beamCooldownCurr = 0.0f;
    public float beamCooldownEnd = 3.0f;
    public Transform target;
    private Vector3 targetPos;

    public void BEAM()
    {
        GameObject heartFired = Instantiate(heartPrefab, firePoint.position, firePoint.rotation);
        targetPos = (target.position - firePoint.position).normalized;
        heartFired.GetComponent<Rigidbody2D>().AddForce(targetPos * fireForce, ForceMode2D.Impulse);
    }

    void Start(){

    }

    void FixedUpdate(){
        if(beamCooldownCurr >= beamCooldownEnd) {
            BEAM();
            beamCooldownCurr = 0.0f;
        }
        else {
            Debug.Log("prepping for a shit");
            beamCooldownCurr += Time.deltaTime;
        }
    }
}
