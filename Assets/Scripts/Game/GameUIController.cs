using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public void OnClickBackButton()
    {
        Debug.Log("Back");
        GameManager.Instance.OpenConfirmPanel("게임을 종료하시겠습니까?");
        // GameManager.Instance.ChangeToMainScene();
    }
    public void OnClickSettingsButton() { }
}
