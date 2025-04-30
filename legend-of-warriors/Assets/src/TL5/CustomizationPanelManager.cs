using System.Collections.Generic;
using UnityEngine;

public class CustomizationPanelManager : MonoBehaviour
{
    public GameObject shopPanel;
    public List<GameObject> customizationPanels;
    public CharacterSelector characterSelector; // assign this in Unity Inspector

    private void OnEnable()
    {
        SceneManagerScript.OnApplyAll += ApplyAllSelections;
        SceneManagerScript.OnDiscardAll += DiscardAllSelections;
    }

    private void OnDisable()
    {
        SceneManagerScript.OnApplyAll -= ApplyAllSelections;
        SceneManagerScript.OnDiscardAll -= DiscardAllSelections;
    }

    // Dynamically toggle any panel
    public void ShowPanel(GameObject panelToShow)
    {
        shopPanel.SetActive(false);

        foreach (GameObject panel in customizationPanels)
            panel.SetActive(panel == panelToShow);
    }

    public void ExitToShopPanel()
    {
        shopPanel.SetActive(true);
        foreach (GameObject panel in customizationPanels)
            panel.SetActive(false);
    }

    // Called from individual Apply buttons
public void ApplySelection(string category)
{
    if (category == "Character")
    {
        characterSelector.ApplySelectedCharacter();
    }

    ExitToShopPanel();
}

    // Called from individual Discard buttons
    public void DiscardSelection(string category)
    {
        Debug.Log($"{category} discarded.");
        // TODO: Reset selection to previous state
        ExitToShopPanel();
    }

    // Called by SceneManagerScript via event
    public void ApplyAllSelections()
    {
        Debug.Log("CustomizationPanelManager: Apply all triggered.");
        // TODO: Apply all panel selections
    }

    public void DiscardAllSelections()
    {
        Debug.Log("CustomizationPanelManager: Discard all triggered.");
        // TODO: Reset all panel selections
    }
}

