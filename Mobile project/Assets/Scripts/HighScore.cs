using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "Best score: " + PlayerPrefs.GetInt("HS").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            GetComponent<Animation>().Play();
        }
    }
}
