using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : GunScript
{
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        weapon_cooldown = 0;
        tf = GetComponent<Transform>();
        Debug.Log(GetComponent<Transform>());
        weapon_current_ammo = weapon_ammo;
    }

    private void OnEnable()
    {
        weapon_current_ammo = weapon_ammo;
        weapon_cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AttackCheck();
        GunDirection();
    }

    #region ShotgunShots
    protected override void AttackCheck()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        mouse_x = worldPosition.x;
        mouse_y = worldPosition.y;
        barrel_x = bullet_spawn.GetComponent<Transform>().position.x;
        barrel_y = bullet_spawn.GetComponent<Transform>().position.y;

        //Checks to see if the weapon is currently on cooldown
        if (weapon_cooldown > 0)
        {
            weapon_cooldown -= Time.deltaTime;
            return;
        }



        //Checks to see if the mouse button is pressed
        if (Input.GetMouseButtonDown(0) && weapon_current_ammo > 0)
        {
            for (int i = 0; i < 6; i += 1)
            {
                GameObject bullet = Instantiate(bullet_object, bullet_spawn.GetComponent<Transform>().position, Quaternion.identity);
                bullet.SetActive(true);
                float x = Random.Range(-1 * weapon_spread, weapon_spread);
                float y = Random.Range(-1 * weapon_spread, weapon_spread);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(mouse_x - barrel_x + x, mouse_y - barrel_y + y).normalized * weapon_bullet_speed;
            }
            
            weapon_sound.Play();
            weapon_cooldown = 60 / weapon_firespeed;
            weapon_current_ammo -= 1;
        }
    }
    #endregion
}
