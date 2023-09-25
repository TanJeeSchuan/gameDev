using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : baseCharacterBehaviour
{
    input playerInput;
    WeaponSwitch WeaponSwitch;

    // Start is called before the first frame update
    protected override void OnStarting()
    {
        playerInput = GetComponentInChildren<input>();
        WeaponSwitch = GetComponentInChildren<WeaponSwitch>();
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        timePassed += Time.deltaTime;
        //Debug.Log(timePassed);


        CharacterMovement.move(playerInput.getXYInput());
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
}
