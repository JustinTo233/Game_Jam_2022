using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    #region SlashProperties
    public float slash_timer;
    private float current_timer;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        current_timer = slash_timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_timer <= 0)
        {
            SlashDestroy();
        }
        current_timer -= Time.deltaTime;


    }

    private void SlashDestroy()
    {
        Destroy(this.gameObject, 0);
    }

    //DO THIS FOR THE COLLIDER
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
