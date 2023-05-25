
using UnityEngine;

public class MainGameMenu : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;

    public void ReloadMainGame()
    {
        _loader.LoadGameLevel();
    }

}
