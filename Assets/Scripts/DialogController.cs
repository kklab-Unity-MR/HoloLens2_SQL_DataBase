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

    public void DataBaseSaveError()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.OK, "エラーメッセージ", "エラーが発生し、設定が保存出来ませんでした", false);
        //Dialog dialog = Dialog.Open(DialogPrefabLarge, DialogButtonType.OK, "Confirmation Dialog, Large, Far", "This is an example of a large dialog with only one button, placed at far interaction range", false);
        if (dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEventOnlyOK;
        }
    }

    public void OpenChoiceDialogPractice()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.Yes | DialogButtonType.No, "演習モード", "\n演習モードを開始しますか？", true);
        if(dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEventPractice1;
        }
    }

    public void OpenChoiceDialogExplanation()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.Yes | DialogButtonType.No, "説明モード", "\n説明モードを開始しますか？", true);
        if (dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEventExplanation1;
        }
    }

    public void OpenChoiceDialogbackHome()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.Yes | DialogButtonType.No, "ホーム画面", "\nホーム画面に戻りますか？", true);
        if (dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEventBackHome;

            
        }
    }

    public void OpenChoiceDialogPractice2()
    {
        Dialog dialog = Dialog.Open(DialogPrefabSmall, DialogButtonType.Yes | DialogButtonType.No, "開発者モード", "\nPractice2に移動しますか？", true);
        if (dialog != null)
        {
            dialog.OnClosed += OnClosedDialogEvenPractice2;


        }
    }

    private void OnClosedDialogEventPractice1(DialogResult result)
    {
        if (result.Result == DialogButtonType.Yes)
        {
            Debug.Log("yesが押されました");
            SceneManager.LoadScene("Practice1");
        }
        
    }

    private void OnClosedDialogEventExplanation1(DialogResult result)
    {
        if (result.Result == DialogButtonType.Yes)
        {
            Debug.Log("yesが押されました");
            SceneManager.LoadScene("explanation1");
        }

    }

    private void OnClosedDialogEventBackHome(DialogResult result)
    {
        if (result.Result == DialogButtonType.Yes)
        {
            Debug.Log("yesが押されました");
            SceneManager.LoadScene("StartMenu");
        }

    }

    private void OnClosedDialogEvenPractice2(DialogResult result)
    {
        if (result.Result == DialogButtonType.Yes)
        {
            Debug.Log("練習2");
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
