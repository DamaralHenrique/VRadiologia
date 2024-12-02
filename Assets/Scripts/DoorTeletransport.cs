using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTeletransport : MonoBehaviour, IInteractable
{
    public string destination;

    void Start()
    {
        Debug.Log($"Configured with destination: {destination}");
    }

    public void Interact()
    {
        Debug.Log("Interacting! with door1");

        Debug.Log("Trocando para a cena " + destination + "...");

        string sceneToLoad = "";
        string spawnPointSuffix = "";

        // if(destination == "ExamRoom"){
        //     sceneToLoad = "ExameRoom";
        //     spawnPointSuffix = "EntraceSpawnPoint";
        // }
        // if(destination == "WaitingRoom"){
        //     sceneToLoad = "WaitingRoom";
        //     spawnPointSuffix = "ExamSpawnPoint";
        // }

        SceneTransitionManager.Instance.LoadScene(destination);
    }
}