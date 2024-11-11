using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public string title;
    public string description;
    public bool isComplete = false;
    public int panelOrder;
    public int completionOrder;
    // UI
    public Text textLabel;
    public Image check;

    void Start()
    {
        Debug.Log(title +" start!");
        if(textLabel){
           textLabel.text = description; 
        }
        if(check){
           check.enabled = isComplete;
        }
    }

    public virtual void CheckComplete()
    {
        Debug.Log("Error not implemented");
    }

    public virtual void OnComplete() {
        if (!isComplete) {
            isComplete = true;
            if(check){
                check.enabled = true;
            }
            
            Debug.Log($"{title} has been completed!");
        }
    }

    public void RequestComplete() {
        Debug.Log("RequestComplete");
        Debug.Log(isComplete);
        if (!isComplete) {
            MissionsSystem.Instance.CompleteMission(this);
        }
    }
}
