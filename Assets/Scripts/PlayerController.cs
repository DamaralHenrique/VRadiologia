using System; // For Action
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public Camera MainCamera;
    public Transform XrActionManager;
    public Transform InputActionManager;
    public Transform VrSimulator;
    public Vector3 startSpawnPosition = Vector3.zero;

    public static PlayerController Instance { get; private set; }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded");
        SetPlayerPositionOnSceneLoad();
    }

    void Awake()
    {
        Debug.Log("PlayerController Awake");

        if (Instance == null){
            Debug.Log("Instance is null");
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(Player);
            DontDestroyOnLoad(XrActionManager);
            DontDestroyOnLoad(InputActionManager);
            DontDestroyOnLoad(VrSimulator);
        }
        else{
            Debug.Log("Destroy");
            Destroy(gameObject);
            Destroy(Player);
            Destroy(XrActionManager);
            Destroy(InputActionManager);
            Destroy(VrSimulator);
        }

        SetPlayerPositionOnSceneLoad();
    }

    void SetPlayerPositionOnSceneLoad()
    {

        Debug.Log("SetPlayerPositionOnSceneLoad");
        string lastScene = SceneTransitionManager.Instance.GetLastScene();
        string spawnPointSuffix = SceneTransitionManager.Instance.GetSpawnPointSuffix();

        Debug.Log(lastScene);
        Debug.Log(spawnPointSuffix);

        if(lastScene != null){
            var spawnPointName = "SpawnPoint" + lastScene;
            if(spawnPointSuffix != null){
                spawnPointName += spawnPointSuffix;
            }
            Debug.Log(spawnPointName);
            GameObject spawnTransform = GameObject.Find(spawnPointName);

            var rotatingAngleY = spawnTransform.transform.rotation.eulerAngles.y - MainCamera.transform.rotation.eulerAngles.y;

            Player.transform.Rotate(0, rotatingAngleY, 0);

            var distanceDiff = spawnTransform.transform.position - MainCamera.transform.position;

            Player.transform.position += distanceDiff;

            Player.SetActive(!Player.activeSelf);
            Player.SetActive(!Player.activeSelf);
        }
        Debug.Log("SetPlayerPositionOnSceneLoad - end");
    }
}
