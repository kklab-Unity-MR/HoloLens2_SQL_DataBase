using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class InputEdit : MonoBehaviour
{
    public TMP_InputField Field;

    public void OnEndEdit()
    {
        string input = Field.GetComponent<TMP_InputField>().text;
        GetComponent<TMP_Text>().text = input;
    }
}
