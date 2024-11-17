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

    public void LoadScene(string sceneName, string spawnPointSuffix)
    {
        Debug.Log("LoadScene");
        lastScene = SceneManager.GetActiveScene().name;
        this.spawnPointSuffix = spawnPointSuffix;
        SceneManager.LoadScene(sceneName);
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;;
    }

    public string GetLastScene()
    {
        return this.lastScene;
    }

    public string GetSpawnPointSuffix()
    {
        return this.spawnPointSuffix;
    }
}