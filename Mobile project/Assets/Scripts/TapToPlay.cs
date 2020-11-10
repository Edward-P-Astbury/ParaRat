using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlay : MonoBehaviour
{
    [SerializeField] private GameObject[] hiddenObjects;

    // Start is called before the first frame update
    void Start()
    {
        HideObjects(hiddenObjects, true);
    }

    // Update is called once per frame
    void Update()
    {
        // If we register a touch we play the game
        if(Input.touchCount > 0)
        {
            GetComponent<Animation>().Play();

            Invoke("StartGame", 2f); // Invoke function after the animation
        }
        
    }

    public void StartGame()
    {
        HideObjects(hiddenObjects, false);

        Destroy(gameObject);
    }

    public void HideObjects(GameObject[] hiddenObjects, bool hide) 
    {
        foreach(GameObject g in hiddenObjects)
        {
            if(hide == true)
            {
                g.SetActive(false);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }
}
