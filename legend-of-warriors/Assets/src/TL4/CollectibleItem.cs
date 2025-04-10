using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName;
    public string itemType;
    public string itemEffect;

    public Sprite itemIcon;


    public void UseItem()
    {
        Debug.Log($"Using {itemName}: {itemEffect}");
    }

    public string GetEffect()
    {
        return itemEffect;
    }
}
