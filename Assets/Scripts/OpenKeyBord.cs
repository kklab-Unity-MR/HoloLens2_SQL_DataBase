using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyBord : MonoBehaviour
{
    private MixedRealityKeyboard wmrKeyboard;

    public void OpenKeyboard()
    {
        wmrKeyboard.ShowKeyboard(wmrKeyboard.Text, false);
    }
}
