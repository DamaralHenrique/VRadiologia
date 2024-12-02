using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraySetMission : BasicInteractionMission
{
    public GameObject Tray;

    public override void OnComplete()
    {
        base.OnComplete();
        ChangeAllComponentsVisibility(this.gameObject, false);
        ChangeAllComponentsVisibility(Tray, true);
    }

    public override void SetMissionPositionOnSceneLoad()
    {
        Debug.Log("Custom SetMissionPositionOnSceneLoad");
        Debug.Log("mission.name: " + this.gameObject.name);
        Debug.Log("Tray.name: " + Tray.name);
        Debug.Log("isComplete: " + isComplete);

        GameObject spawnTransform = GameObject.Find("SpawnPoint" + Tray.name);
        if(spawnTransform){
            ChangeAllComponentsVisibility(Tray, isComplete);
            Tray.transform.rotation = spawnTransform.transform.rotation;

            Tray.transform.position = spawnTransform.transform.position;
        }else{
            Debug.Log("Sem spawn point");
            ChangeAllComponentsVisibility(Tray, false);
        }

        spawnTransform = GameObject.Find("SpawnPoint" + this.gameObject.name);
        if(spawnTransform){
            ChangeAllComponentsVisibility(this.gameObject, !isComplete);
            transform.rotation = spawnTransform.transform.rotation;

            transform.position = spawnTransform.transform.position;
        }else{
            Debug.Log("Sem spawn point");
            ChangeAllComponentsVisibility(this.gameObject, false);
        }
        
    }
}
