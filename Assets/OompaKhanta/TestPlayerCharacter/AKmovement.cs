using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKmovement : MonoBehaviour
{
    public float movement_speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Vertical = Input.GetAxis("Vertical") * movement_speed;
        float Horizontal = Input.GetAxis("Horizontal") * movement_speed;
        transform.Translate(0, Vertical, 0);
        transform.Translate(Horizontal, 0, 0);
    }
}
