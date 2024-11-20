using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;

public class ChildrenInteractWithParentScript : MonoBehaviour
{
    public string scriptName;  // Nome do script presente no pai

    public virtual void Start()
    {
        // Encontra o tipo de script do pai usando o nome
        Type scriptType = Type.GetType(scriptName);

        if (scriptType != null && scriptType.IsSubclassOf(typeof(MonoBehaviour)))
        {
            // Obtém o script do pai usando GetComponent no próprio GameObject
            var parentScript = GetComponent(scriptType);

            if (parentScript != null)
            {
                ConfigureChildWithParentScript(this.gameObject, parentScript);
            }
            else
            {
                Debug.LogWarning($"O script '{scriptName}' não está presente no pai.");
            }
        }
        else
        {
            Debug.LogWarning("Script não encontrado ou inválido: " + scriptName);
        }
    }

    protected void ConfigureChildWithParentScript(GameObject parent, Component parentScript)
    {
        if(parent.transform.childCount == 0){
            return;
        }

        foreach (Transform child in parent.transform)
        {
            ChildScript childScript = child.gameObject.AddComponent<ChildScript>();
            
            childScript.parentScript = parentScript;

            ConfigureChildWithParentScript(child.gameObject, childScript);
        }
    }
}

[Serializable]
public class Parameter
{
    public string Name;  // Nome do parâmetro
    public ParameterType Type;
    public string Value;

    // Converte o valor com base no tipo
    public object GetValue()
    {
        return Type switch
        {
            ParameterType.String => (string)Value,
            ParameterType.Int => int.Parse(Value),
            ParameterType.Float => float.Parse(Value),
            _ => null,
        };
    }
}

public enum ParameterType
{
    String,
    Int,
    Float
}

public class ChildScript : MonoBehaviour, IInteractable
{
    public Component parentScript;

    protected MethodInfo method;

    void Start()
    {
        var type = parentScript.GetType();

        method = type.GetMethod("Interact");
    }

    public void Interact()
    {
        Debug.Log("ChildScript - Interact");
        if (method != null)
        {
            method.Invoke(parentScript, new object[] { });
        }
        else
        {
            Debug.LogWarning($"Método 'Interact' não encontrado no script.");
        }
    }
}