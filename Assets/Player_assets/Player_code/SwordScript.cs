using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : GunScript
{

    #region SwordProperties
    protected bool is_swinging;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        is_swinging = false;
        weapon_cooldown = 0;
        tf = GetComponent<Transform>();
        player_tf = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        AttackCheck();
        if (is_swinging)
        {
            return;
        }
        GunDirection();
    }

    protected override void AttackCheck()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        mouse_x = worldPosition.x;
        mouse_y = worldPosition.y;
        barrel_x = bullet_spawn.GetComponent<Transform>().position.x;
        barrel_y = bullet_spawn.GetComponent<Transform>().position.y;
        if (weapon_cooldown > 0)
        {
            weapon_cooldown -= Time.deltaTime;
            return;
        }
        is_swinging = false;
        
        if (Input.GetMouseButtonDown(0))
        {
            weapon_sound.Play();
            is_swinging = true;
            weapon_cooldown = 60 / weapon_firespeed;
            GameObject slash = Instantiate(bullet_object, player_tf.position, Quaternion.identity);
            pos_x = tf.position.x;
            pos_y = tf.position.y;
            var angle = Mathf.Atan2(mouse_y - pos_y, mouse_x - pos_x) * Mathf.Rad2Deg;
            slash.GetComponent<Transform>().rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            slash.SetActive(true);
            slash.GetComponent<Rigidbody2D>().velocity = new Vector2(mouse_x - barrel_x, mouse_y - barrel_y).normalized * weapon_bullet_speed;
            weapon_cooldown = 60 / weapon_firespeed;
        }
    }

}
