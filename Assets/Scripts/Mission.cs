using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Threading.Tasks;

public class Mission : MonoBehaviour
{
    public string title;
    public string description;
    public bool isComplete = false;
    public bool disappearAfterComplete = true;
    public bool isVisible = true;
    public int panelOrder;
    public int completionOrder;
    // UI
    public TextMeshProUGUI textLabel;
    public Image check;
    public GameObject canvasOverlay;
    public Image targetImage;
    public string imageName;
    public bool hasSpawn = true;
    public Sprite spriteRenderer;

    void Start()
    {
        Debug.Log(title +" start!");
        if(textLabel){
           textLabel.text = (completionOrder+1)+ ". " + description; 
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

            LoadLocalImage();

            Debug.Log("disappearAfterComplete:" + disappearAfterComplete);
            if(disappearAfterComplete){
                isVisible = false;
                ChangeAllComponentsVisibility(this.gameObject, false);
            }
        }
    }

    public void RequestComplete() {
        Debug.Log("RequestComplete");
        Debug.Log(isComplete);
        if (!isComplete) {
            MissionsSystem.Instance.CompleteMission(this);
        }
    }

    public void ChangeAllComponentsVisibility(GameObject obj, bool isVisible)
    {
        ChangeComponentVisibility(obj, isVisible);

        // Desativa o Renderer e Collider em todos os filhos
        foreach (Transform child in obj.transform)
        {
            ChangeAllComponentsVisibility(child.gameObject, isVisible);
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

    public void LoadLocalImage()
    {
        if(spriteRenderer){
            targetImage.sprite = spriteRenderer;

            TextMeshProUGUI targetText = canvasOverlay.GetComponentInChildren<TextMeshProUGUI>();

            targetText.text = "";
            targetImage.enabled = true;
            canvasOverlay.SetActive(true);
        }
    }

    public void ShowError(string error)
    {
        TextMeshProUGUI targetText = canvasOverlay.GetComponentInChildren<TextMeshProUGUI>();

        targetText.text = error;
        canvasOverlay.SetActive(true);
        targetImage.enabled = false;
    }

    virtual public void SetMissionPositionOnSceneLoad()
    {
        Debug.Log("mission.name: " + this.gameObject.name);
        if(hasSpawn){
            GameObject spawnTransform = GameObject.Find("SpawnPoint" + this.gameObject.name);
            Debug.Log("isVisible: " + isVisible);
            if(isVisible && spawnTransform){
                ChangeAllComponentsVisibility(this.gameObject, true);
                transform.rotation = spawnTransform.transform.rotation;

                transform.position = spawnTransform.transform.position;
            }else{
                Debug.Log("Sem spawn point");
                ChangeAllComponentsVisibility(this.gameObject, false);
            } 
        }
        
    }
}
