using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public string selectedCharacterName;

    public void SelectCharacter(string characterName)
    {
        selectedCharacterName = characterName;
        Debug.Log("Selected Character: " + characterName);
    }

    public void ApplySelectedCharacter()
{
    if (!string.IsNullOrEmpty(selectedCharacterName))
    {
        PlayerPrefs.SetString("SelectedCharacter", selectedCharacterName);
        PlayerPrefs.Save(); // Optional
        Debug.Log("✅ Saved character: " + selectedCharacterName);
    }
}
}

