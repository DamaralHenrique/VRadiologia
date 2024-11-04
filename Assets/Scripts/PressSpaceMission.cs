using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceMission : Mission
{

    public override void CheckComplete()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RequestComplete();
        }
    }

    public override void OnComplete()
    {
        base.OnComplete();
        // Do additional stuff
        Debug.Log("Pressed Spacebar!");
    }
}
