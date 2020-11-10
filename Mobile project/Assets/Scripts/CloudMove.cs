using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [SerializeField] GameObject[] cloudObjects;

    // We add and minus five so that the sprite leaves the screen in its entirety
    private float maxValue = Boundaries.ScreenBounds.x + 5;
    private float minValue = -Boundaries.ScreenBounds.x - 5;

    // Dictates the starting position of the sprite 
    private float currentValue = -5;

    // The speed and direction the sprite travels
    private float direction = 2f;

    // Update is called once per frame
    void Update()
    {
        // Incrementing the position
        currentValue += Time.deltaTime * direction;

        if (currentValue >= maxValue)
        {
            direction *= -1;
            currentValue = maxValue;
        }
        else if (currentValue <= minValue)
        {
            direction *= -1;
            currentValue = minValue;
        }

        cloudObjects[0].transform.position = new Vector3(currentValue, 4, 0);
        cloudObjects[1].transform.position = new Vector3(currentValue, 0, 0);
        cloudObjects[2].transform.position = new Vector3(currentValue, -4, 0);
    }
}
