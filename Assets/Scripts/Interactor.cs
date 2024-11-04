using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            Debug.DrawLine(r.origin, new Vector3(transform.position.x, transform.position.y, transform.position.z + interactRange));

            if (Physics.Raycast(r, out RaycastHit hitInfo))
            //if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                Debug.Log(1);

                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                }
            }
        }
        
    }
}
