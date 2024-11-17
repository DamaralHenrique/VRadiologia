using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTeletransport : MonoBehaviour, IInteractable
{
    public string destination;

    void Start()
    {
        Debug.Log($"Configured with destination: {destination}");
    }

    // public void Configure(object[] parameters)
    // {
    //     Debug.Log($"Configured with parameters: {parameters}");

    //     foreach(object param in parameters){
    //         Debug.Log($"Configured with param: {param}");
    //     }
        
    //     destination = (string)parameters[0];

    //     Debug.Log($"Configured with destination: {destination}");
    // }

    public void Interact()
    {
        Debug.Log("Interacting! with door1");

        Debug.Log("Trocando para a cena " + destination + "...");

        string sceneToLoad = "";
        string spawnPointSuffix = "";

        if(destination == "ExamRoom"){
            sceneToLoad = "ExameRoom";
            spawnPointSuffix = "EntraceSpawnPoint";
        }
        // SceneManager.LoadScene(sceneToLoad);
        SceneTransitionManager.Instance.LoadScene(sceneToLoad, spawnPointSuffix);
    }
}