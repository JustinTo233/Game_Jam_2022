using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    #region GameVaraibles
    [SerializeField] protected GameObject bullet_spawn;
    [SerializeField] protected GameObject bullet_object;
    protected Transform tf;
    protected Transform player_tf;

    #endregion

    #region WeaponVariables
    //current weapons stats
    public float weapon_damage;
    public float weapon_reload;
    public float weapon_firespeed;
    public float weapon_spread;
    public float weapon_bullet_speed;
    public float weapon_ammo;
    protected float weapon_current_ammo;
    //Weapon fire cooldown
    protected float weapon_cooldown;

    #endregion
    protected float mouse_x;
    protected float mouse_y;
    protected float barrel_x;
    protected float barrel_y;
    protected float pos_x;
    protected float pos_y;

    // Start is called before the first frame update
    void Start()
    {
        weapon_cooldown = 0;
        tf = GetComponent<Transform>();
        player_tf = GetComponentInParent<Transform>();
        weapon_current_ammo = weapon_ammo;
    }

    // Update is called once per frame
    void Update()
    {
        AttackCheck();
        GunDirection();
    }

    #region AttackFunctions
    protected virtual void AttackCheck()
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
            GameObject bullet = Instantiate(bullet_object, bullet_spawn.GetComponent<Transform>().position, Quaternion.identity);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(mouse_x - barrel_x, mouse_y - barrel_y).normalized * weapon_bullet_speed;
            weapon_cooldown = 60 / weapon_firespeed;
            Debug.Log(bullet.GetComponent<Rigidbody2D>().velocity);
            weapon_current_ammo -= 1;
        }
    }

    protected virtual void GunDirection()
    {
        pos_x = tf.position.x;
        pos_y = tf.position.y;
        var angle = Mathf.Atan2(mouse_y - pos_y, mouse_x - pos_x) * Mathf.Rad2Deg;
        tf.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }


    #endregion
}
