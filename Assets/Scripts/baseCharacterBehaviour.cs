using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class baseCharacterBehaviour : MonoBehaviour
{
    CharacterMovement CharacterMovement;
    input playerInput;
    EquipmentList equipmentList;
    WeaponSwitch WeaponSwitch;
    CurrentWeapon currentWeapon;

    Vector2 inputVec;
    // Start is called before the first frame update
    void Start()
    {
        CharacterMovement = GetComponent<CharacterMovement>();
        equipmentList = GetComponent<EquipmentList>();

        currentWeapon = GetComponentInChildren<CurrentWeapon>();
        currentWeapon.updateEquipedWeapon();

        //GameObject Player = transform.GetChild(0).gameObject;
        //playerInput = Player.GetComponent<input>();
        //WeaponSwitch = Player.GetComponent<WeaponSwitch>();

        playerInput = GetComponentInChildren<input>();
        WeaponSwitch = GetComponentInChildren<WeaponSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec = playerInput.getXYInput();
        CharacterMovement.move(inputVec);

        CharacterMovement.rotate_to_point(playerInput.getMousePos());

        if (playerInput.getWeaponSwitchStatus())
        {
            WeaponSwitch.cycleWeapon(equipmentList);
            currentWeapon.updateEquipedWeapon();
        }

        if (playerInput.getFiringStatus())
        {
            attack();
        }
    }
    void attack()
    {
        currentWeapon.attack();
    }    
}
