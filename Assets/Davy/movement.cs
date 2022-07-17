using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Vertical = Input.GetAxis("Vertical") * .001;
        float Horizontal = Input.GetAxis("Horizontal") * .001;
        transform.Translate(0, Vertical, 0);
        transform.Translate(Horizontal, 0, 0);
    }
}
