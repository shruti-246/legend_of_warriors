using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite to change")]
    public SpriteRenderer bodyPart;

    public List<Sprite> options = new List<Sprite>();

    private int currentIndex = 0;
    
    public void NextOption()
    {
        currentIndex++;
        if (currentIndex >= options.Count)
        {
            currentIndex = 0;
        }
        bodyPart.sprite = options[currentIndex];
    }

    public void PreviousOption()
    {
        currentIndex--;
        if (currentIndex <= 0)
        {
            currentIndex = options.Count - 1;
        }
        bodyPart.sprite = options[currentIndex];
    }
}
