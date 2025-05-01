using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite to change")]
    public SpriteRenderer bodyPart;

    public List<Sprite> options = new List<Sprite>();

    private int currentIndex = 0;

    private const string OutfitKey = "SelectedOutfit";

    void Start()
    {
        // Load saved outfit if exists
        currentIndex = PlayerPrefs.GetInt(OutfitKey, 0);
        if (currentIndex < options.Count)
        {
            bodyPart.sprite = options[currentIndex];
        }
        else
        {
            currentIndex = 0;
            bodyPart.sprite = options[0];
        }
    }

    public void NextOption()
    {
        currentIndex++;
        if (currentIndex >= options.Count)
        {
            currentIndex = 0;
        }
        ApplyAndSave();
    }

    public void PreviousOption()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = options.Count - 1;
        }
        ApplyAndSave();
    }

    private void ApplyAndSave()
    {
        bodyPart.sprite = options[currentIndex];
        PlayerPrefs.SetInt(OutfitKey, currentIndex);
        PlayerPrefs.Save();
    }
}
