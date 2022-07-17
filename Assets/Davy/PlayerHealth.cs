using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int maxHealth = 100;
    public int playerHealth;
    void Start()
    {
        playerHealth = maxHealth;
    }
    public void PlayerTakeDamage(int damage){
        playerHealth = playerHealth - damage;
    }

}