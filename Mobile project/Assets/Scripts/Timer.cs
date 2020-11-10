using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float maxTime = 3f;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Shoot.HasFired == true)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                slider.value = timeLeft / maxTime;
            }
            else
            {
                Shoot.HasFired = false;
                slider.value = maxTime;
                timeLeft = maxTime;
                gameObject.SetActive(false);
            }
        }
    }
}
