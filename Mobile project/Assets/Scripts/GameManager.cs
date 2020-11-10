using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenuContainer, playerContainer;
    private bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenuContainer.SetActive(false);
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverMenuContainer.SetActive(true);
            playerContainer.SetActive(false);
        }
    }
}
