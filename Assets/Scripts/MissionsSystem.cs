using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsSystem : MonoBehaviour
{

    public static MissionsSystem Instance { get; private set; }

    public List<Mission> missions; // = new List<Mission>();
    private int currentCompletionOrder = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
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
        // missions.Sort((m1, m2) => m1.completionOrder.CompareTo(m2.completionOrder));
    }

    private void Update() {
        CheckMissions();
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
}
