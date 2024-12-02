using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientCheckupMission : Mission, IInteractable
{
    public GameObject pacient;
        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        Debug.Log("PatientCheckupMission completed!");
        PatientTakeAwayMission pacientMission = pacient.GetComponent<PatientTakeAwayMission>();
        if (pacientMission != null)
        {
            Debug.Log("Has mission");
            pacientMission.isVisible = true; // Altere o parâmetro
        }
        Debug.Log("Change visibility");
        ChangeAllComponentsVisibility(pacient, true);
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
