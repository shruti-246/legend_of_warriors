using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D other)
        {
            CollectibleItem item = other.GetComponent<CollectibleItem>();
            if (item != null)
            {
                bool added = inventory.AddItem(item);
                if (added)
                {
                    Debug.Log("Collected: " + item.itemName); // ✅ Add this line
                    UIManager.Instance.UpdateInventoryUI(inventory);
                    Destroy(other.gameObject);
                }
                else
                {
                    Debug.Log("Bag is full. Could not collect " + item.itemName);
                }
            }
        }


}
