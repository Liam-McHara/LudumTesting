using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TooltipActivator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string TooltipText = "Default text";
    Tooltip tooltip;

    void Awake()
    {
        tooltip = GameObject.FindGameObjectWithTag("Tooltip").GetComponentInChildren<Tooltip>();
    }

    // PointerEventData eventData
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(TooltipText);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

}
