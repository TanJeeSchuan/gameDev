using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public abstract class baseCharacterBehaviour : MonoBehaviour
{
    protected EquipmentList equipmentList;
    protected CurrentWeapon currentWeapon;
    protected CharacterMovement CharacterMovement;

    [SerializeField]
    public Health health;
    

    protected float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        equipmentList = GetComponent<EquipmentList>();

        currentWeapon = GetComponentInChildren<CurrentWeapon>();
        currentWeapon.updateEquipedWeapon();

        CharacterMovement = GetComponent<CharacterMovement>();

        OnStarting();

        //GameObject Player = transform.GetChild(0).gameObject;
        //playerInput = Player.GetComponent<input>();
        //WeaponSwitch = Player.GetComponent<WeaponSwitch>();
    }
    void Update()
    {
        Debug.Log("test");
        OnUpdate();
    }

    protected void attack()
    {
        if (timePassed > currentWeapon.currentWeapon.attackrate)
        {
            currentWeapon.attack();
            timePassed = 0;
        }
    }

    protected abstract void OnStarting();
    protected abstract void OnUpdate();
}
