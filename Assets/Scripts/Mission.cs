using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mission : MonoBehaviour
{
    public string title;
    public string description;
    public bool isComplete = false;
    public int panelOrder;
    public int completionOrder;
    // UI
    public TextMeshProUGUI textLabel;
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

            ChangeAllComponentsVisibility(false);
        }
    }

    public void RequestComplete() {
        Debug.Log("RequestComplete");
        Debug.Log(isComplete);
        if (!isComplete) {
            MissionsSystem.Instance.CompleteMission(this);
        }
    }

    public void ChangeAllComponentsVisibility(bool isVisible)
    {
        ChangeComponentVisibility(this.gameObject, isVisible);

        // Desativa o Renderer e Collider em todos os filhos
        foreach (Transform child in transform)
        {
            ChangeComponentVisibility(child.gameObject, isVisible);
        }
    }

    protected void ChangeComponentVisibility(GameObject obj, bool isVisible)
    {
        // Desativa o Renderer, se existir
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = isVisible;
        }

        // Desativa o Collider, se existir
        Collider collider = obj.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = isVisible;
        }
    }
}
