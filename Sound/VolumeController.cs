using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the volume settings in the game using a toggle button.
/// </summary>
public class VolumeController : MonoBehaviour {
    [SerializeField]
    Toggle volumeToggle;

    private void Start() {
        LoadVolume();
    }

    /// <summary>
    /// Loads the saved volume settings from PlayerPrefs and applies them to the game.
    /// </summary>
    public void LoadVolume() {
        float volume = PlayerPrefs.GetFloat("GameVolume", 1);
        AudioListener.volume = volume;
        volumeToggle.isOn = volume > 0;
    }

    /// <summary>
    /// Toggles the game volume on/off based on the state of the toggle button.
    /// </summary>
    public void VolumeToggle() {
        float volume = volumeToggle.isOn ? 1.0f : 0.0f;
        PlayerPrefs.SetFloat("GameVolume", volume);
        AudioListener.volume = volume;
    }
}
