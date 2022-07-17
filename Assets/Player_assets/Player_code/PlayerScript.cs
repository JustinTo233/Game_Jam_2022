using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameOver GameOver;

    //PlayerVariables are the base component variables for the player
    #region PlayerVariables
    Rigidbody2D rb;
    Transform tf;
    #endregion

    //MovementVariables deal with the basic movement of the player
    #region MovementVariables
    //movespeed is the movespeed of the player character
    public float move_speed;
    //The raw movement of the x and y direction (Think of a 2d grid)
    float x_movement;
    float y_movement;
    //Mouse location
    float mouse_x;
    float mouse_y;
    //Player locations
    float pos_x;
    float pos_y;
    //move_direction (facing) is the direction the 2d vector the player moves and faces
    //!!!IMPORTANT!!! WILL PROBABLY BE BASED ON MOUSE LOCATION RELATIVE TO THE PLAYER
    private Vector2 move_direction;
    private Vector2 facing_direction;
    //The starting facing direction of the player
    public Vector2 start_facing_direction;
    //Moving boolean
    bool is_moving;
    #endregion

    //DodgeRollVariables deal with the dodgeroll the player has
    #region DodgeRollVariables
    //checks if the palyer is currently dashing
    bool is_dash;
    //the timer of the dash
    private float dash_counter;
    private float dash_cooldown_current;
    //Changeable properties of the dash
    public float dash_time;
    public float dash_velocity;
    public float dash_cooldown_duration;
    #endregion

    //WeaponVaraibles
    /// <summary>
    /// Will do something about this later as I haven't decided if I'll use an array or use a master asset with children
    /// </summary>
    #region WeaponVariables
    public GameObject[] weapon_array;
    //The integer value of the current weapon in the weapon array
    public int weapon_start;
    private int weapon_current;
    //current weapons stats
    private float weapon_damage;
    private float weapon_reload;
    private float weapon_firespeed;
    private float weapon_spread;
    //The weapon in question
    private GameObject weapon;
    private Transform weapon_tf;
    #endregion

    //AttackVariables deal with the player attacks (heavily based on weapon variables)
    #region AttackVariables
    #endregion

    //HealthVariables
    #region HealthVariables
    public float health_max;
    private float health_current;
    //checks if you are hit
    private bool is_hit;
    //The time you are invulnurable and the current invul time left
    public float invul_time;
    private float invul_time_current;
    //Maybe use maybe not
    bool is_invul;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //Gets Components
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();

        //Set starting booleans
        is_hit = false;
        is_invul = false;
        is_dash = false;
        //Set starting values
        health_current = health_max;
        facing_direction = start_facing_direction;
        dash_cooldown_current = 0;
        weapon_current = weapon_start;
        GunSpawn();
        /*
        GunDirection();
        */

    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
        Debug.Log(weapon_array);
        /*
        GunDirection();
        */
    }

    #region MovementFunctions
    private void MovementCheck()
    {
        dash_cooldown_current -= Time.deltaTime;
        //Raw Input Obtaining
        x_movement = Input.GetAxisRaw("Horizontal");
        y_movement = Input.GetAxisRaw("Vertical");

        //May move mouse stuff somewhere else
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        mouse_x = worldPosition.x;
        mouse_y = worldPosition.y;

        //Position obtaining
        pos_x = tf.position.x;
        pos_y = tf.position.y;

        //Checks if the player is dashing
        if (is_dash)
        {
            dash_counter -= Time.deltaTime;
            if (dash_counter <= 0)
            {
                is_dash = false;
                dash_cooldown_current = dash_cooldown_duration;
                weapon_current = Random.Range(0, weapon_array.Length);
                GunSpawn();
                
            }
            return;
        }

        
        
        move_direction = new Vector2(x_movement, y_movement);
        facing_direction = new Vector2(mouse_x - pos_x, mouse_y - pos_y);

        //Checks if we are moving or not
        if (move_direction != Vector2.zero)
        {
            is_moving = true;

        } else
        {
            is_moving = false;
        }

        //Dashes the character
        //TODO: Check to see if we want a spotdodge or not
        if (Input.GetKey("space") && dash_cooldown_current <= 0)
        {
            is_dash = true;
            dash_counter = dash_time;
            rb.velocity = move_direction.normalized * dash_velocity;
            dash_cooldown_current = dash_cooldown_duration;
            GunRemoval();

        }
        else
        {
            rb.velocity = move_direction.normalized * move_speed;
        }


    }

    #endregion

    #region AttackFunctions
    private void GunSpawn()
    {
        Debug.Log(weapon_current);
        weapon = weapon_array[weapon_current];
        weapon_tf = weapon.GetComponent<Transform>();
        weapon.SetActive(true);
    }

    private void GunRemoval()
    {
        weapon.SetActive(false);
    }
    /*
    private void GunDirection()
    {
        //Places the weapon on the player always (SUBJECT TO CHANGE)
        weapon_tf.position = new Vector3(tf.position.x, tf.position.y, weapon_tf.position.z);
        var angle = Mathf.Atan2(mouse_y - pos_y, mouse_x - pos_x) * Mathf.Rad2Deg;
        weapon_tf.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        
    }
    */
    #endregion

    #region HealthFunctions
    public bool TakeDamage(float damage)
    {
        if (is_invul || is_dash)
        {
            return false;
        } else
        {
            health_current -= damage;
            if (health_current <= 0)
            {
                PlayerDeath();
            }
            return true;
        }
        
    }

    //IMPORTANT GAME MANAGER HERE
    public void PlayerDeath()
    {
        GameOver;
    }
    #endregion

}
