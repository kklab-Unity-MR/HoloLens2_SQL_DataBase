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

    public void OnEndEdit()
    {
        input = Field.GetComponent<TMP_InputField>().text;
        GetComponent<TMP_Text>().text = input;
    }

    public string GetInputText()
    {   
        return input;
    }
}
