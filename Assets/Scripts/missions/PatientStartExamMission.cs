using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientStartExamMission : Mission, IInteractable
{
    public GameObject door;
    public GameObject pacient;
    public GameObject pacientLayDown;


        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        Debug.Log("PatientStartExamMission completed!");

        Vector3 rotation = door.transform.rotation.eulerAngles;
        rotation.y = 14.297f;
        door.transform.rotation = Quaternion.Euler(rotation);

        pacientLayDown.SetActive(false);

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
