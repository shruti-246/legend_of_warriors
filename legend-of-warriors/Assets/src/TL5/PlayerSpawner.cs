using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class PlayerSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform spawnPoint;

    [System.Serializable]
    public class CharacterEntry
    {
        public string characterName;
        public GameObject prefab;
    }

    public List<CharacterEntry> characters; // assign in Inspector
    private Dictionary<string, GameObject> prefabLookup;

void Start()
{
    // Build lookup
    prefabLookup = new Dictionary<string, GameObject>();
    foreach (var entry in characters)
    {
        if (!string.IsNullOrEmpty(entry.characterName) && entry.prefab != null)
            prefabLookup[entry.characterName] = entry.prefab;
    }

    if (!PlayerPrefs.HasKey("SelectedCharacter"))
    {
        Debug.LogWarning("[PlayerSpawner] No character selected. Skipping override.");
        return;
    }

    string selected = PlayerPrefs.GetString("SelectedCharacter", "");
    Debug.Log("[PlayerSpawner] Selected from PlayerPrefs: " + selected);

    if (!prefabLookup.TryGetValue(selected, out GameObject selectedPrefab) || selectedPrefab == null)
    {
        Debug.LogError("[PlayerSpawner] ❌ Prefab not found for: " + selected);
        return;
    }

    // 🧠 Instead of instantiating, find the existing player
    GameObject existingPlayer = GameObject.FindWithTag("Player");
    if (existingPlayer == null)
    {
        Debug.LogError("[PlayerSpawner] No existing player found with tag 'Player'.");
        return;
    }

    // ✅ Replace the visuals (sprite, animator, etc.)
    CopyAppearanceFromPrefab(selectedPrefab, existingPlayer);

    // Optional: Move the player to spawn point
    if (spawnPoint != null)
        existingPlayer.transform.position = spawnPoint.position;
}

void CopyAppearanceFromPrefab(GameObject prefab, GameObject target)
{
    // 🧼 Hide all existing children (modular visuals)
    foreach (Transform child in target.transform)
    {
        child.gameObject.SetActive(false);
    }

    // ✅ Instantiate the selected prefab as a visual child
    GameObject newVisual = Instantiate(prefab, target.transform);
    newVisual.transform.localPosition = Vector3.zero;

    // ✅ Optionally match scale, rotation
    newVisual.transform.localScale = Vector3.one * 1.0f;
    newVisual.transform.localPosition = new Vector3(0, 4.0f, 0); // 🎯 Adjust Y only
    newVisual.transform.localRotation = Quaternion.identity;

    Debug.Log("✅ Replaced player visuals with: " + prefab.name);
}

}