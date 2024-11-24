using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientTakeAwayMission : Mission, IInteractable
{
    public GameObject pacient;
        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        Debug.Log("PatientTakeAwayMission completed!");
        PatientLayDownMission pacientMission = pacient.GetComponent<PatientLayDownMission>();
        if (pacientMission != null)
        {
            Debug.Log("Has mission");
            pacientMission.isVisible = true; // Altere o parâmetro
        }
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
