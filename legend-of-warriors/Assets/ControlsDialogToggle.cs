using UnityEngine;

public class ControlsDialogToggle : MonoBehaviour
{
    public static bool isDialogOpen = false;

    public GameObject controlsDialogBox;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleControlsDialog();
        }
    }

    public void ToggleControlsDialog()
    {
        if (controlsDialogBox != null)
        {
            bool isActive = !controlsDialogBox.activeSelf;
            controlsDialogBox.SetActive(isActive);
            isDialogOpen = isActive;
        }
    }
}