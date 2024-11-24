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
        BasicInteractionMission pacientMission = pacient.GetComponent<BasicInteractionMission>();
        if (pacientMission != null)
        {
            Debug.Log("Has mission");
            pacientMission.isVisible = true; // Altere o parâmetro
        }
        // ChangeAllComponentsVisibility(this.gameObject, false);
        Debug.Log("Change visibility");
        ChangeAllComponentsVisibility(pacient, true);
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
