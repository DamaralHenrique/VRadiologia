using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ApplyMissionScriptToChildren : ApplyScriptToChildren
{
    public string title;
    public string description;
    public bool isComplete = false;
    public int panelOrder;
    public int completionOrder;
    // UI
    public TextMeshProUGUI textLabel;
    public Image check;

    public override void Start()
    {
        Type scriptType = Type.GetType(scriptName);
        if (scriptType != null && scriptType.IsSubclassOf(typeof(MonoBehaviour)))
        {
            foreach (Transform child in transform)
            {
                Collider collider = child.GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = true;
                }

                var component = child.gameObject.GetComponent(scriptType);
                if (component == null)
                {
                    component = child.gameObject.AddComponent(scriptType);
                }

                ConfigureScript(component, Parameters);
                ApplyParamiter(component, title, nameof(title));
                ApplyParamiter(component, description, nameof(description));
                ApplyParamiter(component, isComplete, nameof(isComplete));
                ApplyParamiter(component, panelOrder, nameof(panelOrder));
                ApplyParamiter(component, completionOrder, nameof(completionOrder));
                ApplyParamiter(component, textLabel, nameof(textLabel));
                ApplyParamiter(component, check, nameof(check));
            }
        }
        else
        {
            Debug.LogWarning("Script não encontrado ou inválido: " + scriptName);
        }
    }

    protected void ApplyParamiter(Component component, object parameter, string parameterName){
        // nameof(parameter);
        Debug.Log("nameof(parameter): " + nameof(parameter));
        var type = component.GetType();
        var property = type.GetProperty(parameterName);
        if (property != null && property.CanWrite)
        {
            property.SetValue(component, parameter);
        }
        else
        {
            var field = type.GetField(parameterName);
            if (field != null)
            {
                field.SetValue(component, parameter);
            }
            else
            {
                Debug.LogWarning($"Membro '{parameterName}' não encontrado ou não é acessível no script '{type.Name}'.");
            }
        }
    }

    // override void ConfigureScript(Component component, List<Parameter> parameters)
    // {
    //     var type = component.GetType();
    //     foreach (var parameter in parameters)
    //     {
    //         var property = type.GetProperty(parameter.Name);
    //         if (property != null && property.CanWrite)
    //         {
    //             property.SetValue(component, parameter.GetValue());
    //         }
    //         else
    //         {
    //             var field = type.GetField(parameter.Name);
    //             if (field != null)
    //             {
    //                 field.SetValue(component, parameter.GetValue());
    //             }
    //             else
    //             {
    //                 Debug.LogWarning($"Membro '{parameter.Name}' não encontrado ou não é acessível no script '{type.Name}'.");
    //             }
    //         }
    //     }
    // }
}

// [Serializable]
// public class Parameter
// {
//     public string Name; // Nome do parâmetro (opcional, apenas para referência)
//     public ParameterType Type;
//     public string Value;
//     // public string StringValue;
//     // public int IntValue;
//     // public float FloatValue;

//     // Converte o valor com base no tipo
//     public object GetValue()
//     {
//         return Type switch
//         {
//             ParameterType.String => (string) Value,
//             ParameterType.Int => int.Parse(Value),
//             ParameterType.Float => float.Parse(Value),
//             _ => null,
//         };
//         // return Type switch
//         // {
//         //     ParameterType.String => StringValue,
//         //     ParameterType.Int => IntValue,
//         //     ParameterType.Float => FloatValue,
//         //     _ => null,
//         // };
//     }
// }

// public enum ParameterType
// {
//     String,
//     Int,
//     Float
// }