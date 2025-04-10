using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxCapacity = 5;
    public List<CollectibleItem> items = new List<CollectibleItem>();

    public bool AddItem(CollectibleItem item)
    {
        if (items.Count >= maxCapacity)
        {
            Debug.Log("Bag is full!");
            return false;
        }

        items.Add(item);
        return true;
    }

    public void RemoveItem(CollectibleItem item)
    {
        items.Remove(item);
    }

    public List<CollectibleItem> GetItems()
    {
        return items;
    }

    public int GetAvailableSpace()
    {
        return maxCapacity - items.Count;
    }
}
