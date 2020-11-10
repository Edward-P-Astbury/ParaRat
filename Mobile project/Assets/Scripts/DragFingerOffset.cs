using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerOffset : MonoBehaviour
{
    private float deltaX, deltaY;
    private Rigidbody2D rb;
    private Shoot shoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Move the object through Rigidbody2D
        shoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Zero refers to the first touch

            // touchPos is converted to world space, Unity co-ordinates, rather than pixel space
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    // Calling Fire method
                    shoot.Fire(touchPos);

                    // Calculate offset between touch and object
                    // Each variable represents the difference between touch position and object position 
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    // Object is moved in the same direction as finger using the calculated offset
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;

                case TouchPhase.Ended:
                    // Velocity and object is stopped
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }
}
