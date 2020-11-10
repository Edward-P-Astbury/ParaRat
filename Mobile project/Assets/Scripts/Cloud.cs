using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float minSpeed = 1;
    private float maxSpeed = 3;

    private float minY = -4;
    private float maxY = 4;

    // The additional length for the sprite to spawn outside the bounds of the screen
    private float buffer = 5;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        transform.position = new Vector3(-Boundaries.ScreenBounds.x - buffer, Random.Range(minY, maxY), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Times by Time.deltaTime to become frame rate independant
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if(transform.position.x - buffer > Boundaries.ScreenBounds.x)
        {
            Destroy(gameObject);
        }
    }
}
