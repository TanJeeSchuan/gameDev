using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character_Mov : MonoBehaviour
{
    Rigidbody2D rb;

    public Vector2 maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        rotate_to_mouse();
    }

    void move()
    {
        Vector2 pos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.position += pos * Time.deltaTime * maxSpeed;
    }
    void rotate_to_mouse()
    {
        float a = angle_between_points(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, a + 90));
    }
    float angle_between_points(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec1.y - vec2.y, vec1.x - vec2.x) * Mathf.Rad2Deg;
    }
}
