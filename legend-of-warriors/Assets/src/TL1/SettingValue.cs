// using UnityEngine;

// Superclass
// public class SettingValue
// {
//     public virtual void Apply()
//     {
//         Apply(true); // Default behavior: save
//     }

//     public virtual void Apply(bool save)
//     {
//         AudioListener.volume = 5.0f;
//         Debug.Log($"BASE Apply(save:{save}) called – volume hardcoded to 5");
//     }
// }


// Subclass
// public class VolumeSetting : SettingValue
// {
//     private float volume;

//     public VolumeSetting(float volume)
//     {
//         this.volume = volume;
//     }

//     public override void Apply()
//     {
//         Apply(save: true); // default to saving when not specified
//     }

//     public void Apply(bool save)
//     {
//         AudioListener.volume = volume;
//         if (save)
//         {
//             PlayerPrefs.SetFloat("Volume", volume);
//         }
//         Debug.Log($"Dynamic Volume applied: {volume}, Saved: {save}");
//     }
// }

using UnityEngine;

//Superclass
public class SettingValue
{
    public virtual void Apply()
    {
        Apply(true); // Default behavior: save
    }

    public virtual void Apply(bool save)
    {
        AudioListener.volume = 5.0f;
        Debug.Log($"BASE Apply(save:{save}) called – volume hardcoded to 5");
    }
}


//Subclass
public class VolumeSetting : SettingValue
{
    private float volume;

    public VolumeSetting(float volume)
    {
        this.volume = volume;
    }

    public override void Apply()
    {
        Apply(save: true); // default to saving when not specified
    }

    public override void Apply(bool save)
    {
        AudioListener.volume = volume;
        if (save)
        {
            PlayerPrefs.SetFloat("Volume", volume);
        }
        Debug.Log($"Dynamic Volume applied: {volume}, Saved: {save}");
    }
}
