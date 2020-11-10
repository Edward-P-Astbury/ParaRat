using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Camera MainCamera;
    private static Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;

        // Screen boundaries converted to world space
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Only need to know half of the object's dimensions because we clamp the objects at their centre
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; // extents = size of height / 2
    }

    // LateUpdate is called once per frame, after Update has finished, used for physics
    void LateUpdate()
    {
        // Alter objects X and Y co - ordinates
        Vector3 viewPos = transform.position;

        // Clamp current objects X and Y position to the screen boundaries
        // Negative in front of a variable is the same as doing screenBounds * -1
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);

        // Set position to equal new altered position
        transform.position = viewPos;
    }

    public static Vector2 ScreenBounds
    {
        get
        {
            return screenBounds;
        }
    }
}
