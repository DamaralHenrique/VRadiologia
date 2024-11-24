using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientCloseDoorMission : Mission, IInteractable
{
    public GameObject door;
        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        Debug.Log("PatientCloseDoorMission completed!");
        Vector3 rotation = door.transform.rotation.eulerAngles;
        rotation.y = -90;
        door.transform.rotation = Quaternion.Euler(rotation);
        // ChangeAllComponentsVisibility(pacient, true);
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }

    public override void SetMissionPositionOnSceneLoad()
    {
        Debug.Log("Custom SetMissionPositionOnSceneLoad");
        Debug.Log("mission.name: " + this.gameObject.name);
        GameObject spawnTransform = GameObject.Find("SpawnPoint" + door.name);
        if(spawnTransform){
            ChangeAllComponentsVisibility(door, true);
            door.transform.rotation = spawnTransform.transform.rotation;

            door.transform.position = spawnTransform.transform.position;
        }else{
            Debug.Log("Sem spawn point");
            ChangeAllComponentsVisibility(door, false);
        }

        spawnTransform = GameObject.Find("SpawnPoint" + this.gameObject.name);
        if(isVisible && spawnTransform){
            ChangeAllComponentsVisibility(this.gameObject, true);
            transform.rotation = spawnTransform.transform.rotation;

            transform.position = spawnTransform.transform.position;
        }else{
            Debug.Log("Sem spawn point");
            ChangeAllComponentsVisibility(this.gameObject, false);
        }
    }
}
