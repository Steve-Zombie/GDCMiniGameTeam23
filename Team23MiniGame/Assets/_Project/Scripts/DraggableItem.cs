using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("References")]
    [SerializeField] private Item item;

    private Canvas canvas;
    private Image dragGhost;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragGhost = new GameObject("Drag Ghost", typeof(Image)).GetComponent<Image>();
        dragGhost.transform.SetParent(canvas.transform, false);
        dragGhost.sprite = GetComponent<Image>().sprite;
        dragGhost.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out var localPos
        );
        dragGhost.rectTransform.anchoredPosition = localPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragGhost != null)
            Destroy(dragGhost.gameObject);
    }
}
