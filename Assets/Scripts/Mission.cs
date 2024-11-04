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

    public virtual void CheckComplete()
    {
        Debug.Log("Error not implemented");
    }

    public virtual void OnComplete() {
        if (!isComplete) {
            isComplete = true;
            Debug.Log($"{title} has been completed!");
        }
    }

    public void RequestComplete() {
        if (!isComplete) {
            MissionsSystem.Instance.CompleteMission(this);
        }
    }
}
