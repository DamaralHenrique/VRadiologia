using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour {
    public Transform interactorSource;
    public float interactRange = 5f;
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer lastRenderer;

    public InputActionReference rightTriggerAction;

    private void Awake() {
        rightTriggerAction.action.Enable();
        rightTriggerAction.action.performed += ManageInteractions;
    }

    private void OnDestroy() {
        rightTriggerAction.action.Disable();
        rightTriggerAction.action.performed -= ManageInteractions;
    }

    // Start is called before the first frame update
    void Start() {
        highlightMaterial = Resources.Load<Material>("Outline");

        if (highlightMaterial == null) {
            Debug.LogError("Highlight Material não encontrado na pasta Resources!");
        }
    }

    // Update is called once per frame
    void Update() {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        Debug.DrawLine(r.origin, r.origin + r.direction * interactRange, Color.red);

        if(Physics.Raycast(r, out RaycastHit hitInfo, interactRange)) {
             if (hitInfo.collider.gameObject.TryGetComponent(out Renderer renderer)) {
                // Se o último renderer não é o mesmo do atual, restaure os materiais anteriores
                if (lastRenderer != null && lastRenderer != renderer) {
                    // Remove o highlight do último objeto
                    RemoveHighlight(lastRenderer);
                }

                // Armazena o objeto atual
                lastRenderer = renderer;

                // Adiciona o material de highlight
                AddHighlight(renderer, hitInfo.collider.gameObject.name);
            }
        }else if (lastRenderer != null) {
            // Remove o highlight quando não há mais um objeto no alvo
            RemoveHighlight(lastRenderer);
            lastRenderer = null;
        }

    }

    void AddHighlight(Renderer renderer, string objectName) {
        // Cria uma nova lista de materiais
        Material[] materials = renderer.materials;

        // Verifica se o material de highlight já está na lista
        foreach (var mat in materials) {
            if (mat.name == highlightMaterial.name + " (Instance)") {
                return;
            }
        }

        Material customizedHighlightMaterial = new Material(highlightMaterial);

        if (objectName == "Cube.001") { // PatientCheckup
            customizedHighlightMaterial.SetFloat("_Outline_Thickness", 0.0001f);
        } else {
            customizedHighlightMaterial.SetFloat("_Outline_Thickness", 0.0287f);
        }

        // Cria um novo array com espaço para o novo material
        Material[] newMaterials = new Material[materials.Length + 1];
        materials.CopyTo(newMaterials, 0); // Copia os materiais existentes
        newMaterials[newMaterials.Length - 1] = customizedHighlightMaterial; // Adiciona o novo material

        // Aplica a nova lista de materiais ao renderer
        renderer.materials = newMaterials;
    }

    void RemoveHighlight(Renderer renderer) {
        // Recupera os materiais atuais
        Material[] materials = renderer.materials;

        // Cria uma nova lista que não inclui o highlightMaterial
        List<Material> materialList = new List<Material>(materials);
        foreach (var mat in materials) {
            if (mat.name == highlightMaterial.name + " (Instance)") {
                materialList.Remove(mat); // Remove o material de highlight
            }
        }

        // Aplica a nova lista de materiais ao renderer
        renderer.materials = materialList.ToArray();
    }

    void ManageInteractions(InputAction.CallbackContext context) {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        Debug.DrawLine(r.origin, r.origin + r.direction * interactRange, Color.red);

        if(Physics.Raycast(r, out RaycastHit hitInfo, interactRange)) {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                interactObj.Interact();
            }
        }
    }
}
