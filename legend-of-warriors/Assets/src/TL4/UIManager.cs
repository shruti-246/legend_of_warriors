using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject inventoryPanel;
    public GameObject itemButtonPrefab;
    public Transform itemListContent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate managers
        }
    }

    void Update()
    {
        // Close inventory when ESC is pressed
        if (inventoryPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void UpdateInventoryUI(Inventory inventory)
    {
        if (itemButtonPrefab == null || itemListContent == null)
        {
            Debug.LogError("UIManager is missing UI references.");
            return;
        }

        // Clear old buttons
        foreach (Transform child in itemListContent)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("Inventory contains: " + inventory.GetItems().Count + " items");

        foreach (CollectibleItem item in inventory.GetItems())
        {
            GameObject button = Instantiate(itemButtonPrefab, itemListContent);
            Debug.Log("Instantiated button for: " + item.itemName);

            // Set item name
            var label = button.GetComponentInChildren<TextMeshProUGUI>();
            if (label == null)
            {
                Debug.LogError("No TextMeshProUGUI found in ItemButton prefab!");
            }
            else
            {
                label.text = "Drop  " + item.itemName;
            }

            // Set icon
            Image icon = button.transform.Find("ItemIcon").GetComponent<Image>();
            if (icon != null && item.itemIcon != null)
            {
                icon.sprite = item.itemIcon;
            }

            // Button functionality (remove item)
            button.GetComponent<Button>().onClick.AddListener(() => {
                inventory.RemoveItem(item);
                Destroy(button);
            });
        }
    }
}
