using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameLevel()
    {
        SceneManager.LoadScene(0);
    }
}
