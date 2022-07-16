using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Vertical = Input.GetAxis("Vertical") * 0.01f;
        float Horizontal = Input.GetAxis("Horizontal") * 0.01f;
        transform.Translate(0, Vertical, 0);
        transform.Translate(Horizontal, 0, 0);
    }
}
