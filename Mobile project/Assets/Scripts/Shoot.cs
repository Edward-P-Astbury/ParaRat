using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private static bool hasFired = false;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject bulletShell;
    private bool fingerOverSprite;

    [SerializeField] private GameObject[] mouseParts;
    [SerializeField] private GameObject[] mouseTrapParts;

    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer chosenPlayerSprite;

    // Start is called before the first frame update
    void Start()
    {
        chosenPlayerSprite = GetComponent<SpriteRenderer>();

        ScopeSelection();
    }

    public void Fire(Vector2 touchPos)
    {
        fingerOverSprite = GetComponent<SpriteRenderer>().bounds.Contains(touchPos);

        if (fingerOverSprite == true && hasFired == false)
        {
            // Fire
            timer.SetActive(true);
            hasFired = true;

            bulletShell.GetComponent<ParticleSystem>().Play();

            // RaycastHit2D from touchPos and forward direction out of the main camera
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            AudioManager.instance.Play("FireMiss");

            if (hitInformation.transform.gameObject.CompareTag("Enemy"))
            {
                // tempObject we collided with through the RaycastHit2D
                GameObject tempObject = hitInformation.transform.gameObject;

                // Increase the PlayerScore
                Score.PlayerScore++;

                AudioManager.instance.Play("FireHit");

                // Update the high score of the player
                if(Score.PlayerScore > PlayerPrefs.GetInt("HS"))
                {
                    PlayerPrefs.SetInt("HS", Score.PlayerScore);
                }

                PartsSpawn(mouseParts);

                Destroy(tempObject);
            }
            else if(hitInformation.transform.gameObject.CompareTag("EnemyTrap"))
            {
                AudioManager.instance.Play("FireWrongTarget");

                PartsSpawn(mouseTrapParts);

                Destroy(hitInformation.transform.gameObject);
            }
        }
    }

    public void PartsSpawn(GameObject[] parts)
    {
        foreach(GameObject g in parts)
        {
            Instantiate(g, transform.position, Quaternion.identity); // Quaternion.identity means no rotation
        }
    }

    public void ScopeSelection()
    {
        switch(PlayerPrefs.GetInt("scopeSelected"))
        {
            case 0:
                chosenPlayerSprite.sprite = sprites[0];
                break;
            case 1:
                chosenPlayerSprite.sprite = sprites[1];
                break;
            case 2:
                chosenPlayerSprite.sprite = sprites[2];
                break;
        }
    }

    public static bool HasFired
    {
        get
        {
            return hasFired;
        }
        set
        {
            hasFired = value;
        }
    }
}
