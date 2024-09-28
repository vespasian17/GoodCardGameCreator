using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransactor : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
