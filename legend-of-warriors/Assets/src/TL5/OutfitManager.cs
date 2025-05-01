using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    [System.Serializable]
    public class OutfitPart
    {
        public string name;
        public SpriteRenderer spriteRenderer;
        public Sprite[] options;
        public string saveKey;
    }

    public OutfitPart[] outfitParts;

    void Start()
    {
        LoadAllOutfits();
    }

    void LoadAllOutfits()
    {
        foreach (var part in outfitParts)
        {
            LoadOutfitPart(part);
        }
    }

    void LoadOutfitPart(OutfitPart part)
    {
        if (part.spriteRenderer == null || part.options == null || part.options.Length == 0)
        {
            Debug.LogWarning($"[OutfitManager] Invalid setup for part: {part.name}");
            return;
        }

        int savedIndex = PlayerPrefs.GetInt(part.saveKey, 0);
        if (savedIndex >= 0 && savedIndex < part.options.Length)
        {
            part.spriteRenderer.sprite = part.options[savedIndex];
            Debug.Log($"[OutfitManager] Loaded {part.name} option {savedIndex}");
        }
        else
        {
            Debug.LogWarning($"[OutfitManager] Invalid saved index for {part.name}: {savedIndex}");
        }
    }
} 