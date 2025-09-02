using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainPanelController : MonoBehaviour
{
    public void OnClickSinglePlayButton()
    {
        Debug.Log("Single");
        GameManager.Instance.ChangeToGameScene(Constants.GameType.SinglePlay);
    }

    public void OnClickDualPlayButton()
    {
        Debug.Log("Dual");
        GameManager.Instance.ChangeToGameScene(Constants.GameType.DualPlay);
    }

    public void OnClickMultiPlayButton()
    {
        Debug.Log("Multi");
        GameManager.Instance.ChangeToGameScene(Constants.GameType.MultiPlay);
    }
    public void OnClickSettingsButton() { Debug.Log("Settings");}
}