using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceMission : Mission
{
    public string title = "Press Space";
    public string description = "teste teste teste";
    public bool isComplete = false;
    public int panelOrder = 1;
    public int completionOrder = 1;

    public override bool CheckComplete()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            return true;
        }
        return false;
    }

    public override void OnComplete()
    {
        Debug.Log("Pressed Spacebar!");
    }

    public void Start()
    {
        Debug.Log("oi");
    }
}
