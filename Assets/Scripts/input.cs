using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class input : MonoBehaviour
{
    private Vector2 inputVector;
    private Vector2 mousePosition;
    private bool firingState;

    //void Update()
    //{
    //    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}
    public Vector2 getXYInput()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return inputVector;
    }
    public Vector2 getMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }    

    public bool getFiringStatus()
    {
        firingState = Input.GetButtonDown("Fire1");
        return firingState;
    }

    public bool getWeaponSwitchStatus()
    {
        return Input.GetButtonDown("Switch");
    }
}
