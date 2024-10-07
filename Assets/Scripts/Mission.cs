using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public string displayName;
    public string description;
    public bool isComplete = false;
    public int panelOrder;
    public int completionOrder;

    public bool CheckComplete()
    {
        Console.WriteLine("Error not implemented");
        return false;
    }

    public void OnComplete()
    {
        Console.WriteLine("Error not implemented");
    }

    public void Update()
    {
        if (!this.isComplete && CheckComplete())
        {
            this.isComplete = true;
            OnComplete();
        }
    }
}
