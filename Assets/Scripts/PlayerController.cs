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
        SetPlayerPositionOnSceneLoad();
    }

    void Awake()
    {
        Debug.Log("PlayerController Awake");
        // DontDestroyOnLoad(Player);
        // DontDestroyOnLoad(XrActionManager);
        // DontDestroyOnLoad(InputActionManager);
        // DontDestroyOnLoad(VrSimulator);

        if (Instance == null){
          Instance = this;
          DontDestroyOnLoad(gameObject);
          DontDestroyOnLoad(Player);
          DontDestroyOnLoad(XrActionManager);
          DontDestroyOnLoad(InputActionManager);
          DontDestroyOnLoad(VrSimulator);
        }
        else{
            Destroy(gameObject);
        }

        SetPlayerPositionOnSceneLoad();
    }

    void SetPlayerPositionOnSceneLoad()
    {

        Debug.Log("SetPlayerPositionOnSceneLoad");
        string lastScene = SceneTransitionManager.Instance.GetLastScene();
        string spawnPointSuffix = SceneTransitionManager.Instance.GetSpawnPointSuffix();

        if(lastScene != null){
          GameObject spawnTransform = GameObject.Find(spawnPointSuffix);

          var rotatingAngleY = spawnTransform.transform.rotation.eulerAngles.y - MainCamera.transform.rotation.eulerAngles.y;

          Player.transform.Rotate(0, rotatingAngleY, 0);

          var distanceDiff = spawnTransform.transform.position - MainCamera.transform.position;

          Player.transform.position += distanceDiff;
        }
        
        // Vector3 spawnPosition;
        // string lastScene = SceneTransitionManager.Instance.GetLastScene();
        // string spawnPointSuffix = SceneTransitionManager.Instance.GetSpawnPointSuffix();

        // if (lastScene == null)
        // {
        //     Debug.Log("First scene");
        //     spawnPosition = startSpawnPosition;
        // }
        // else
        // {
        //     Debug.Log("Last scene: " + lastScene);
        //     // var spawnPointName = "SpawnPoint" + lastScene + spawnPointSuffix;
        //     var spawnPointName = spawnPointSuffix;
        //     Debug.Log("spawnPointName: " + spawnPointName);
        //     spawnPosition = GameObject.Find(spawnPointName).transform.position;
        // }

        // // transform.position = spawnPosition;
        // XrRig.transform.position = spawnPosition;
        // // MainCamera.transform.position = spawnPosition;
        // MainCamera.transform.position = new Vector3(0, 0, 0);
        // Debug.Log("Player position: " + transform.position);
    }
}
