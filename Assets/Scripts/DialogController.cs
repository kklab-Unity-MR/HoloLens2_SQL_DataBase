using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{   
    [SerializeField]
    [Tooltip("Assign DialogLarge_192x192.prefab")]
    private GameObject dialogPrefabLarge;

    [SerializeField]
    [Tooltip("Assign DialogMediume_192x128.prefab")]
    private GameObject dialogPrefabMedium;

    [SerializeField]
    [Tooltip("Assign DialogSmall_192x96.prefab")]
    private GameObject dialogPrefabSmall;

    //プロパティ -> そのクラスの外側から見ればフィールド・クラスの内側からみればメソッド
    public GameObject DialogPrefabLarge
    {
        get => dialogPrefabLarge;
        set => dialogPrefabLarge = value;
    }

    public GameObject DialogPrefabMedium
    {
        get => dialogPrefabMedium;
        set => dialogPrefabMedium = value;
    }

    public GameObject DialogPrefabSmall
    {
        get => dialogPrefabSmall;
        set => dialogPrefabSmall = value;
    }

    public void OpenNullEnputyDialog()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.OK, "エラーメッセージ", "SSID, Password, その両方が空白です", false);
        //Dialog dialog = Dialog.Open(DialogPrefabLarge, DialogButtonType.OK, "Confirmation Dialog, Large, Far", "This is an example of a large dialog with only one button, placed at far interaction range", false);
        if (dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEventOnlyOK;
        }
    }

    public void DataBaseSaveErrorDialog()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.OK, "エラーメッセージ", "エラーが発生し、設定が保存出来ませんでした", false);
        //Dialog dialog = Dialog.Open(DialogPrefabLarge, DialogButtonType.OK, "Confirmation Dialog, Large, Far", "This is an example of a large dialog with only one button, placed at far interaction range", false);
        if (dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEventOnlyOK;
        }
    }

    public void NotAlphanumeric()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.OK, "エラーメッセージ", "SSID, Passwordに全角が使用されています\n半角英数で入力してください", false);
        //Dialog dialog = Dialog.Open(DialogPrefabLarge, DialogButtonType.OK, "Confirmation Dialog, Large, Far", "This is an example of a large dialog with only one button, placed at far interaction range", false);
        if (dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEventOnlyOK;
        }
    }


    private void OnClosedDialogEventOnlyOK(DialogResult result)
    {
        if (result.Result == DialogButtonType.OK)
        {
            Debug.Log("OKが押されました");
        }

    }
}
