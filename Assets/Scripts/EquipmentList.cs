using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipmentList : MonoBehaviour
{
    public List<WeaponBaseClass> weaponList;
    private int weaponIndex;
    private int maxIndex;

    public WeaponBaseClass getEquipedWeapon()
    {
        Debug.Log(weaponIndex);
        return weaponList[weaponIndex];
    }
    public void cycleWeapon()
    {
        if (weaponIndex + 1 == weaponList.Count)
            weaponIndex = 0;
        else
            weaponIndex += 1;
    }
}
