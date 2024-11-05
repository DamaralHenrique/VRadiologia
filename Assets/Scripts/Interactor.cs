using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    // public float interactRange;

    public float interactRange = 5f;
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer lastRenderer;

    // Start is called before the first frame update
    void Start()
    {
         highlightMaterial = Resources.Load<Material>("Outline");

        // Verifique se o material foi carregado corretamente
        if (highlightMaterial == null)
        {
            Debug.LogError("Highlight Material não encontrado na pasta Resources!");
        }
        // // Verifica se highlightMaterial foi arrastado; se não, cria um novo material com o shader de highlight
        // if (highlightMaterial == null)
        // {
        //     // Substitua "HighlightShaderName" pelo nome exato do shader de highlight que você criou/importou
        //     Material highlightMaterial = Material.Find("Outline");
        //     if (highlightMaterial == null)
        //     {
        //         Debug.LogWarning("Material de highlight não encontrado!");
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     Ray r = new Ray(interactorSource.position, interactorSource.forward);
        //     // Debug.DrawLine(r.origin, new Vector3(transform.position.x, transform.position.y, transform.rotation.z + interactRange));
        //     Debug.DrawLine(r.origin, r.origin + r.direction * interactRange, Color.red);

        //     if (Physics.Raycast(r, out RaycastHit hitInfo))
        //     //if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        //     {
        //         Debug.Log(1);

        //         if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
        //             interactObj.Interact();
        //         }
        //     }
        // }

        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        Debug.DrawLine(r.origin, r.origin + r.direction * interactRange, Color.red);

        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (Input.GetKeyDown(KeyCode.P)){
                Debug.Log(1);
                Debug.Log("P!");

                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                }
            }
            
            // Debug.Log("name:  " + hitInfo.collider.gameObject.name);
            // Debug.Log("renderer:  " + hitInfo.collider.gameObject.TryGetComponent(out Renderer renderer2));
            if (hitInfo.collider.gameObject.TryGetComponent(out Renderer renderer))
            {
                // Debug.Log("entrou!");
                // Se o último renderer não é o mesmo do atual, restaure os materiais anteriores
                if (lastRenderer != null && lastRenderer != renderer)
                {
                    // Remove o highlight do último objeto
                    RemoveHighlight(lastRenderer);
                }

                // Armazena o objeto atual
                lastRenderer = renderer;

                // Adiciona o material de highlight
                AddHighlight(renderer);
            }
        }
        else if (lastRenderer != null)
        {
            // Remove o highlight quando não há mais um objeto no alvo
            RemoveHighlight(lastRenderer);
            lastRenderer = null;
        }        
    }

    void AddHighlight(Renderer renderer)
    {
        // Cria uma nova lista de materiais
        Material[] materials = renderer.materials;

        // Verifica se o material de highlight já está na lista
        foreach (var mat in materials)
        {
            if (mat.name == highlightMaterial.name + " (Instance)")
            {
                return;
            }
        }

        // Cria um novo array com espaço para o novo material
        Material[] newMaterials = new Material[materials.Length + 1];
        materials.CopyTo(newMaterials, 0); // Copia os materiais existentes
        newMaterials[newMaterials.Length - 1] = highlightMaterial; // Adiciona o novo material

        // Aplica a nova lista de materiais ao renderer
        renderer.materials = newMaterials;
    }

    void RemoveHighlight(Renderer renderer)
    {
        // Recupera os materiais atuais
        Material[] materials = renderer.materials;

        // Cria uma nova lista que não inclui o highlightMaterial
        List<Material> materialList = new List<Material>(materials);
        foreach (var mat in materials)
        {
            Debug.Log(mat.name);
            Debug.Log(highlightMaterial.name);
            if (mat.name == highlightMaterial.name + " (Instance)")
            {
                materialList.Remove(mat); // Remove o material de highlight
            }
        }

        // Aplica a nova lista de materiais ao renderer
        renderer.materials = materialList.ToArray();
    }
}
