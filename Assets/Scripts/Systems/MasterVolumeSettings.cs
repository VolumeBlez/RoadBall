
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _uiSlider;

    private const string VOLUME_SAVE_KEY = "VOLUME_SAVE_KEY";
    private float currentVolume;

    private void Start() 
    {
        try
        {
            currentVolume = (float)SaveLoadMemorySystem.Instance.GetInt(VOLUME_SAVE_KEY);
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        
        _uiSlider.value = currentVolume;
    }

    public void SetMusicVolume(float value) 
    {
        _mixer.SetFloat("MasterVolume", value);
    }

    private void OnDisable() 
    {
        _mixer.GetFloat("MasterVolume", out float currentVolume);
        SaveLoadMemorySystem.Instance.SaveInt((int)currentVolume, VOLUME_SAVE_KEY);
    }
}
