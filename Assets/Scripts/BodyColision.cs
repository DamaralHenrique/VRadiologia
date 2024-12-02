using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColision : MonoBehaviour
{
    public Transform Head;
    public Transform Feet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Head.position.x, Feet.position.y, Head.position.z);
    }
}
