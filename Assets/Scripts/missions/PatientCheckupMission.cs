using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientCheckupMission : Mission, IInteractable
{
        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        Debug.Log("PatientCheckupMission completed!");
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
