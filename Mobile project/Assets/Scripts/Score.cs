using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private static int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScore.ToString();
    }

    public static int PlayerScore
    {
        get
        {
            return playerScore;
        }
        set
        {
            playerScore = value;
        }
    }
}
