using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WeaponHitDetection : MonoBehaviour
{
    private GameObject hitObject;
    private void OnCollisionStay2D(Collision2D other)
    {
        hitObject = other.gameObject;
    }
    public GameObject getHitObject()
    {
        return hitObject;
    }
}
