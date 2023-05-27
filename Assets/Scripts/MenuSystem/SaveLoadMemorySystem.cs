using UnityEngine;

public class SaveLoadMemorySystem : MonoBehaviour
{
    public static SaveLoadMemorySystem Instance;
    void Awake()
    {
        if( Instance == null)
        {
            Instance = this;
        }
    }

    public void SaveInt(int value, string key)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    
}
