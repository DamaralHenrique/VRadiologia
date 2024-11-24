using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MissionsSystem : MonoBehaviour
{

    public static MissionsSystem Instance { get; private set; }

    public List<Mission> missions;
    public Dictionary<int, int> missionsByOrder;
    private int currentCompletionOrder = 0;
    private int currentMissionsByOrder = 0;

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
        Debug.Log("MissionsSystem - Start");
        Debug.Log(missions);

        missions.Sort((m1, m2) => m1.completionOrder.CompareTo(m2.completionOrder));

        missionsByOrder = missions
            .GroupBy(mission => mission.completionOrder) 
            .ToDictionary(group => group.Key, group => group.Count());
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
            if(missionsByOrder[currentCompletionOrder] == currentMissionsByOrder+1){
                currentCompletionOrder++;
                currentMissionsByOrder = 0;
            }else{
                currentMissionsByOrder++;
            }
        }
        else {
            Debug.Log($"Error: Attempted to complete mission '{mission.title}' out of order. " +
                           $"Current order: {currentCompletionOrder}, Mission order: {mission.completionOrder}" +
                           $"Current Missions By Order: {currentMissionsByOrder}");
            mission.ShowError("Ordem incorreta, verifique a lista de missões novamente");
        }
    }

    void SetMissionsPositionOnSceneLoad()
    {
        Debug.Log("MissionsSystem - SetMissionsPositionOnSceneLoad");

        foreach(Mission mission in missions){
            mission.SetMissionPositionOnSceneLoad();
        }

        Debug.Log("MissionsSystem - SetMissionsPositionOnSceneLoad - end");
    }
}
