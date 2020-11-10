using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject mousePrefab;
    private float respawnTime;
    private bool gameGoing;
    private SpriteRenderer mouseSprite;

    // Start is called before the first frame update
    void Start()
    {
        gameGoing = true;
        StartCoroutine(MouseWave());

        mouseSprite = mousePrefab.GetComponent<SpriteRenderer>();

        if(mousePrefab.CompareTag("Enemy"))
        {
            respawnTime = 5.5f;
        }
        else if(mousePrefab.CompareTag("EnemyTrap"))
        {
            respawnTime = 20.5f;
        }
    }

    public void SpawnEnemy()
    {
        // Cast as GameObject so we instantiate gameobjects
        GameObject temp = Instantiate(mousePrefab) as GameObject;

        // We add * 2 so that the sprite is created outside the bounds of the game screen
        temp.transform.position = new Vector2(Random.Range(-Boundaries.ScreenBounds.x + mouseSprite.bounds.extents.x, Boundaries.ScreenBounds.x - mouseSprite.bounds.extents.x), Boundaries.ScreenBounds.y * 2);
    }

    public IEnumerator MouseWave()
    {
        while (gameGoing == true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
