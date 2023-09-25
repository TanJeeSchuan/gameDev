using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CurrentWeapon : MonoBehaviour
{
    public WeaponBaseClass currentWeapon;
    public EquipmentList equipmentList;

    SpriteRenderer spriteRenderer;
    Animator animator;

    GameObject hitbox;
    GameObject hitObject;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        updateEquipedWeapon();
    }
    public WeaponBaseClass updateEquipedWeapon()
    {
        currentWeapon = equipmentList.getEquipedWeapon();

        try
        {
            animator.runtimeAnimatorController = currentWeapon.weaponAnimationController;
        }
        catch
        {
            Debug.Log("No Controller");
        }
        try
        {
            Debug.Log(currentWeapon.sprite.ToString());
            spriteRenderer.sprite = currentWeapon.sprite;
        }
        catch
        {
            Debug.Log("No sprite");
        }

        return currentWeapon;
    }

    public void attack()
    {
        animator.SetTrigger("Attacking");

        hitbox = currentWeapon.hitboxInstantiate(transform);
        currentWeapon.attack();


        hitObject = hitbox.GetComponent<WeaponHitDetection>().getHitObject();       //get hit object
        if (hitObject.GetComponent<baseCharacterBehaviour>() != null)               //if hitobject has a health component
        {
            hitObject.GetComponent<baseCharacterBehaviour>().health.modifyHealth(-currentWeapon.damage);   //decrease health by damage
            Debug.Log(hitObject.GetComponent<baseCharacterBehaviour>().health.health);
        }

        StartCoroutine(AttackWait());
    }   
    
    public IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(hitbox);
    }

}
