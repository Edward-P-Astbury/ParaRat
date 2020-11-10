using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;
    private int[] speedValueChecks = { 5, 10, 15 };

    // Start is called before the first frame update
    void Start()
    {
        MouseSpeed();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // - 2 for extra padding
        // Delete gameobject once it is no longer visible
        if (transform.position.y < -Boundaries.ScreenBounds.y - 2)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                // Lose the game
                AudioManager.instance.Play("MouseLeftScreen");
                FindObjectOfType<GameManager>().EndGame();
            }

            Destroy(gameObject);
        }
    }

    public void MouseSpeed()
    {
        if(Score.PlayerScore > speedValueChecks[2])
        {
            speed = Random.Range(-2f, -2.5f);
            return;
        }
        if(Score.PlayerScore > speedValueChecks[1])
        {
            speed = Random.Range(-1.5f, -2f);
            return;
        }
        if(Score.PlayerScore > speedValueChecks[0])
        {
            speed = Random.Range(-1.0f, -1.5f);
            return;
        }
        else
        {
            speed = Random.Range(-0.5f, -1.0f);
        }
    }
}
