using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject playerATurnPanel;
    [SerializeField] private GameObject playerBTurnPanel;
    [SerializeField] private TextMeshProUGUI playerTurnInfoText;

    public enum GameTurnPanelType { None, ATurn, BTurn }
    
    public void OnClickBackButton()
    {
        GameManager.Instance.OpenConfirmPanel("게임을 종료하시겠습니까?", () =>
        {
            GameManager.Instance.ChangeToMainScene();
        });
    }

    public void SetGameTurnPanel(GameTurnPanelType gameTurnPanelType)
    {
        switch (gameTurnPanelType)
        {
            case GameTurnPanelType.None:
                playerATurnPanel.SetActive(false);
                playerBTurnPanel.SetActive(false);
                playerTurnInfoText.text = "게임이 곧 시작됩니다.";
                break;
            case GameTurnPanelType.ATurn:
                playerATurnPanel.SetActive(true);
                playerBTurnPanel.SetActive(false);
                playerTurnInfoText.text = "Player A의 차례입니다.";
                break;
            case GameTurnPanelType.BTurn:
                playerATurnPanel.SetActive(false);
                playerBTurnPanel.SetActive(true);
                playerTurnInfoText.text = "Player B의 차례입니다.";
                break;
        }
    }
}
