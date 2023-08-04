using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 maxSpeed;
    public Rigidbody2D rb;

    public void move(Vector2 inputVec)
    {
        //Vector2 pos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.position += inputVec * Time.deltaTime * maxSpeed;
    }
    public void rotate_to_point(Vector2 inputVec)
    {
        float a = angle_between_points(transform.position, inputVec);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, a + 180));
    }
    float angle_between_points(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec1.y - vec2.y, vec1.x - vec2.x) * Mathf.Rad2Deg;
    }
}
