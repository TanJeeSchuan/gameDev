using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponBaseClass : ScriptableObject
{
    public static int currentID = 1;

    public int weaponID;
    public string weaponName;
    public string weaponDesc;
    public float attackrate;
    public float damage;

    public RuntimeAnimatorController weaponAnimationController;
    public Sprite sprite;

    private void Awake()
    {
        weaponID = currentID;
        currentID++;

    }

    public virtual void attack()
    {
        ;
    }
}

[CreateAssetMenu]
public class Arc : WeaponBaseClass
{
    public string damageType = "Slice";
    public Angle angle;
    public float radius;

    public override void attack()
    {
        Debug.Log("Arc Attack");
    }
}

[CreateAssetMenu]
public class Stab : WeaponBaseClass
{
    public string damageType = "Stab";
    public float range;

    public override void attack()
    {
        Debug.Log("Stab Attack");
    }
}

[CreateAssetMenu]
public class Hitscan : WeaponBaseClass
{
    public string damageType = "Shoot";
    public override void attack()
    {
        Debug.Log("Hitscan Attack");
    }
}

[CreateAssetMenu]
public class Projectile : WeaponBaseClass
{
    public string damageType = "Blast";

    public float projectileSpeed;
    public float size;
    public float speed;

    public override void attack()
    {
        Debug.Log("Projectile Attack");
    }
}

[CreateAssetMenu]
public class Area : WeaponBaseClass
{
    public string damageType = "Energy";
    public float radius;

    public override void attack()
    {
        Debug.Log("Area Attack");
    }
}