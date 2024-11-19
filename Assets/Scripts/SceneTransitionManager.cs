using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    private string lastScene;
    private string spawnPointSuffix;

    void Awake()
    {
        Debug.Log("SceneTransitionManager Awake");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName, string spawnPointSuffix = null)
    {
        Debug.Log("SceneTransitionManager - LoadScene");
        lastScene = SceneManager.GetActiveScene().name;
        Debug.Log("lastScene: " + lastScene);
        this.spawnPointSuffix = spawnPointSuffix;
        SceneManager.LoadScene(sceneName);
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;;
    }

    public string GetLastScene()
    {
        Debug.Log("GetLastScene");
        return this.lastScene;
    }

    public string GetSpawnPointSuffix()
    {
        return this.spawnPointSuffix;
    }
}