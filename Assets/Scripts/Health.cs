using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour
{
    public float maxHealth;
    public float health;

    public void fullHealth()
    {
        health = maxHealth;
    }

    public void modifyHealth(float healthModifyValue)
    {
        health += healthModifyValue;

        if (health > maxHealth)
            health = maxHealth;

        if (health < 0)
            health = 0;
    }
}
