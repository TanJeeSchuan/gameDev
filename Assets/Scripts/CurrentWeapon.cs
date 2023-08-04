using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    public WeaponBaseClass currentWeapon;
    public EquipmentList equipmentList;

    SpriteRenderer spriteRenderer;
    Animator animator;
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
        currentWeapon.attack();
    }    
}
