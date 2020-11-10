using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY;

    // Adds rotation to Rigidbody
    private float torque;

    // Start is called before the first frame update
    void Start()
    {
        dirX = Random.Range(-5, 5);
        dirY = Random.Range(5, 8);
        torque = Random.Range(5, 15);

        // Reference to Rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Adds force to the Rigidbody using its mass
        rb.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);

        rb.AddTorque(torque, ForceMode2D.Force);

        Destroy(gameObject, 2f);
    }
}
