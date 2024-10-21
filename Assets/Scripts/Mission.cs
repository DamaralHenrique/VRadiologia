using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public string title;
    public string description;
    public bool isComplete = false;
    public int panelOrder;
    public int completionOrder;

    public virtual bool CheckComplete()
    {
        //Debug.Log("Error not implemented");
        return false;
    }

    public virtual void OnComplete()
    {
        //Debug.Log("Error not implemented");
    }

    public void Update()
    {
        if (!this.isComplete && CheckComplete())
        {
            this.isComplete = true;
            OnComplete();
        }
    }

    public void Start()
    {

    }
}
