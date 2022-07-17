using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    #region SlashProperties
    public float slash_timer;
    public float slash_damage;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            collision.gameObject.SendMessage("TakeDamage", slash_damage);
            SlashDestroy();
        }
    }
}
