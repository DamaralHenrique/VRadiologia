using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionsSystem : MonoBehaviour
{

    public static MissionsSystem Instance { get; private set; }

    public List<Mission> missions;
    private int currentCompletionOrder = 0;

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
        Debug.Log("MissionsSystem - OnSceneLoaded");
        SetMissionsPositionOnSceneLoad();
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Debug.LogWarning("Multiple instances of MissionsSystem detected! Destroying the new instance.");
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {
        Debug.Log(missions);
        foreach (var mission in missions) {
            Debug.Log(mission.name);
            Debug.Log(mission.completionOrder);
        }
         missions.Sort((m1, m2) => m1.completionOrder.CompareTo(m2.completionOrder));
    }

    private void Update() {
        // CheckMissions();
    }

    public void CheckMissions() {
        foreach (var mission in missions) {
            if (!mission.isComplete) {
                mission.CheckComplete();
            }
        }
    }

    public void AddMission(Mission mission) {
        missions.Add(mission);
        missions.Sort((m1, m2) => m1.completionOrder.CompareTo(m2.completionOrder));
    }

    public void CompleteMission(Mission mission) {
        if (mission.completionOrder == currentCompletionOrder) {
            mission.OnComplete();
            currentCompletionOrder++;
        }
        else {
            Debug.LogError($"Error: Attempted to complete mission '{mission.title}' out of order. " +
                           $"Current order: {currentCompletionOrder}, Mission order: {mission.completionOrder}");
        }
    }

    void SetMissionsPositionOnSceneLoad()
    {
        Debug.Log("MissionsSystem - SetMissionsPositionOnSceneLoad");

        foreach(Mission mission in missions){
            Debug.Log("mission.name: " + mission.name);
            GameObject spawnTransform = GameObject.Find("SpawnPoint" + mission.name);
            if(mission.isVisible && spawnTransform){
                mission.ChangeAllComponentsVisibility(true);
                mission.transform.rotation = spawnTransform.transform.rotation;

                mission.transform.position = spawnTransform.transform.position;
            }else{
                Debug.Log("Sem spawn point");
                mission.ChangeAllComponentsVisibility(false);
            }
        }

        Debug.Log("MissionsSystem - SetMissionsPositionOnSceneLoad - end");
    }
}
