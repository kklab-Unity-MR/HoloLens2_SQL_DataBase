using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputEdit : MonoBehaviour
{
    public TMP_InputField Field;

    private string input = null;

    private bool isDataBaseSaved = false;

    public void OnEndEdit()
    {   
        if(isDataBaseSaved is false)
        {
            input = Field.GetComponent<TMP_InputField>().text;
            GetComponent<TMP_Text>().text = input;
        }
        
    }

    public string GetInputText()
    {   
        return input;
    }

    public void SetIsDataBaseSaved(bool isFromAzureTableStrageSpript)
    {
        isDataBaseSaved = isFromAzureTableStrageSpript;
    }
}
