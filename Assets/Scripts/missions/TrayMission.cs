using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayMission : BasicInteractionMission
{
    public GameObject Tray;

    public override void OnComplete()
    {
        base.OnComplete();
        ChangeAllComponentsVisibility(Tray, false);
    }

    public override void SetMissionPositionOnSceneLoad()
    {
        Debug.Log("Custom SetMissionPositionOnSceneLoad");
        Debug.Log("mission.name: " + this.gameObject.name);
        GameObject spawnTransform = GameObject.Find("SpawnPoint" + Tray.name);
        if(isVisible && spawnTransform){
            ChangeAllComponentsVisibility(Tray, true);
            Tray.transform.rotation = spawnTransform.transform.rotation;

            Tray.transform.position = spawnTransform.transform.position;
        }else{
            Debug.Log("Sem spawn point");
            ChangeAllComponentsVisibility(Tray, false);
        }
    }
}
