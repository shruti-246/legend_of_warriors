# Prefab: Button

## Description
This prefab represents a reusable **UI Button** designed for core menu navigation in the game (such as *Play*, *Quit*, *Settings*, *Help*). It can be customized in size, color, icon, and behavior. This prefab helps enforce UI consistency and streamline the button setup process for various game panels.

## Purpose
To allow modular, drag-and-drop UI buttons with pre-assigned styling, transition settings, and text formatting across different menus in the game.

## Includes
- Unity `Button` component  
- `Image` component with pre-set source sprite (e.g., parchment or steampunk style)  
- `TextMeshPro - Text` component (label inside the button)  
- Optional highlight color/press effects  
- Prefab-level anchoring and alignment  

## Features
- Consistent font and sprite styling  
- Easily reskinned (swap sprites)  
- Accepts events like `onClick()` via Inspector  
- Works across different panels: **Main Menu**, **Pause Menu**, **Shop**, **Achievements**  
- Built-in support for prefab variants (e.g., HelpButton, ExitButton, ApplyButton)  

## Example Usage

```csharp
// Assigning a function to the prefab button dynamically in code
Button myButton = Instantiate(buttonPrefab, canvasTransform).GetComponent<Button>();
myButton.onClick.AddListener(() => Debug.Log("Button Clicked!"));
