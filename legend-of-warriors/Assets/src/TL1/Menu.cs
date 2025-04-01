using UnityEngine;

public class Menu : MonoBehaviour
{
    public virtual void OpenMenu()
    {
        Debug.Log("Base Menu opened.");
    }

    public virtual void CloseMenu()
    {
        Debug.Log("Base Menu closed.");
    }
}
