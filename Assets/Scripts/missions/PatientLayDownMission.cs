using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLayDownMission : Mission, IInteractable
{
    public GameObject pacient;        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        Debug.Log("PatientLayDownMission completed!");
        pacient.SetActive(true);
        // ChangeAllComponentsVisibility(pacient, true);
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
