using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeSelect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer scopeSprite;
    [SerializeField] private Sprite[] options;
    private int index;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < options.Length; i++)
        {
            if(i == index)
            {
                scopeSprite.sprite = options[i];

                PlayerPrefs.SetInt("scopeSelected", index);
            }
        }
    }

    public void SwapRight()
    {
        // Minus one because arrays start at 0
        if (index < options.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
    }

    public void SwapLeft()
    {
        if (index == 0)
        {
            index = 2;
        }
        else
        {
            index--;
        }
    }
}
