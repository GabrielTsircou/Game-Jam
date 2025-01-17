using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButtons : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer sr;

    int index;

    public void Left()
    {
        if (index > 0)
        {
            index--;
            sr.sprite = sprites[index];
        }
    }
    public void Right()
    {
        if (index < sprites.Length - 1)
        {
            index++;
            sr.sprite = sprites[index];
        }
    }
}
