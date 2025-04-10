// superclass
public class SettingValue
{
    // Virtual method to be overridden
    public virtual void Apply()
    {
        // Default implementation (optional)
        UnityEngine.Debug.Log("Base setting applied.");
    }
}

//subclass
public class VolumeSetting : SettingValue
{
    private float volume;

    public VolumeSetting(float volume)
    {
        this.volume = volume;
    }
    // Overrides Apply() — this is what gets called dynamically
    // Dynamic method override
    public override void Apply()
    {
        UnityEngine.AudioListener.volume = volume;
        UnityEngine.PlayerPrefs.SetFloat("Volume", volume);
        UnityEngine.Debug.Log($" Dynamic Volume applied: {volume}");
    }
}
