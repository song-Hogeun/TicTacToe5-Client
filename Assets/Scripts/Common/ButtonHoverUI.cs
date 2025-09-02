using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image thisImg;
    private TextMeshProUGUI thisText;

    private void Awake()
    {
        thisImg = GetComponent<Image>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        thisImg.color = new Color(thisImg.color.r, thisImg.color.g, thisImg.color.b, 0.4f);
        thisText.color = Color.black;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        thisImg.color = new Color(thisImg.color.r, thisImg.color.g, thisImg.color.b, 1);
        thisText.color = Color.white;
    }
}