using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractionMission : Mission, IInteractable
{
        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
