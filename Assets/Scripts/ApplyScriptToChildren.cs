using UnityEngine;
using System;

public class ApplyScriptToChildren : MonoBehaviour
{
  public string scriptName;
  void Start()
  {
    Type scriptType = Type.GetType(scriptName);
    if (scriptType != null && scriptType.IsSubclassOf(typeof(MonoBehaviour))){
      // Percorre todas as crianças do objeto pai e aplica a lógica necessária
      foreach (Transform child in transform){
        // Verifica se o filho tem um Collider e adiciona caso n tenha
        Collider collider = child.GetComponent<Collider>();
        if (collider != null)
        {
          collider.enabled = true;
        }

        if (child.gameObject.GetComponent(scriptType) == null)
        {
          child.gameObject.AddComponent(scriptType);
        }
      }
    }
    else {
        Debug.LogWarning("Script não encontrado ou inválido: " + scriptName);
    }
  }
}