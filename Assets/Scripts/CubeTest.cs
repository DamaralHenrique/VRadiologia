using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : Mission, IInteractable
{
        
    public override void CheckComplete()
    {
        //
    }

    public override void OnComplete()
    {
        base.OnComplete();
        // Do additional stuff
        Debug.Log("CubeTest completed!");
    }

    public void Interact()
    {
        Debug.Log("Interacting!");
        RequestComplete();
    }
}
