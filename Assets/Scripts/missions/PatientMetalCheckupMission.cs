using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientMetalCheckupMission : Mission, IInteractable
{
        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        Debug.Log("PatientMetalCheckupMission completed!");
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
