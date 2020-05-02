using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TooltipActivator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string TooltipText = "Default text";
    Tooltip tooltip;

    void Awake()
    {
        tooltip = FindObjectOfType<Tooltip>().GetComponent<Tooltip>();
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
