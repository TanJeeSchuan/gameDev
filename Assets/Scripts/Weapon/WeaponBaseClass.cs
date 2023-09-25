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

    protected float timePassed;

    private void Awake()
    {
        weaponID = currentID;
        currentID++;
    }

    public virtual GameObject hitboxInstantiate(Transform inputTransform)
    {
        return null;
    }
    public virtual void attack()
    {
        timePassed = Time.deltaTime;
    }
}

[CreateAssetMenu]
public class Hitbox : WeaponBaseClass
{
    [SerializeField]
    public GameObject hitboxObjectPrefab;
    public string damageType = "Slice";

    void Awake()
    {
    }

    IEnumerator attackPause()
    {
        yield return new WaitForSeconds(1);
    }
    public override GameObject hitboxInstantiate(Transform inputTransform)
    {
        GameObject hitboxObject = Instantiate(hitboxObjectPrefab);       //create gameObject
        hitboxObject.transform.position = inputTransform.position;
        hitboxObject.transform.rotation = inputTransform.rotation;

        return hitboxObject;
    }

    public override void attack()
    {
        Debug.Log(hitboxObjectPrefab.GetComponent<Collider2D>());
    }

    //private class WeaponAttackCollision : MonoBehaviour
    //{
    //    private Arc weaponClass;
    //    private void OnTriggerStay2D(Collider2D other)
    //    {
    //        Health characterHealth = other.GetComponent<Health>();

    //        if(characterHealth != null)
    //        {
    //            characterHealth.modifyHealth(weaponClass.damage);
    //        }
    //    }
    //}
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

//[CreateAssetMenu]
//public class Stab : WeaponBaseClass
//{
//    public string damageType = "Stab";
//    public float range;

//    public override void attack()
//    {
//        Debug.Log("Stab Attack");
//    }
//}

//[CreateAssetMenu]
//public class Area : WeaponBaseClass
//{
//    public string damageType = "Energy";
//    public float radius;

//    public override void attack()
//    {
//        Debug.Log("Area Attack");
//    }
//}