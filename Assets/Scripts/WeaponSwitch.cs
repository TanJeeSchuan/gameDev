using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public void cycleWeapon(EquipmentList inputEquipmentList)
    {
        inputEquipmentList.cycleWeapon();
    }
}
