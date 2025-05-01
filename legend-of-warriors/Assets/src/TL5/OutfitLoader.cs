using UnityEngine;
using System.Collections.Generic;

public class OutfitLoader : MonoBehaviour
{
    [Header("Body Part")]
    public SpriteRenderer bodyPart; // e.g., pelvis, torso, face, hood

    [Header("Outfit Options")]
    public List<Sprite> options = new List<Sprite>(); // only matching sprites

    // Unique key for each body part
    public string outfitKey = "SelectedPelvis";  // Change to SelectedTorso, SelectedHood, etc. per GameObject

    void Start()
    {
        int index = PlayerPrefs.GetInt(outfitKey, 0);
        Debug.Log($"[OutfitLoader] Key: {outfitKey} | Index: {index}");

        if (options != null && options.Count > 0 && index >= 0 && index < options.Count)
        {
            bodyPart.sprite = options[index];
            Debug.Log($"[OutfitLoader] Applied: {options[index]?.name}");
        }
        else
        {
            Debug.LogWarning($"[OutfitLoader] Invalid index ({index}) or empty list for key: {outfitKey}");
        }
    }
}
