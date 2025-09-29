using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("References")]
    [SerializeField] private Image image;
    [SerializeField] private Item item;

    private Canvas _rootCanvas;
    private Image _dragGhost;

    /// public access of item data
    public Item Item => item;

    void OnValidate()
    {
        if (item != null)
            image.sprite = item.sprite;
    }

    void Awake()
    {
        _rootCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragGhost = new GameObject("Drag Ghost", typeof(Image)).GetComponent<Image>();
        _dragGhost.transform.SetParent(_rootCanvas.transform, false);
        _dragGhost.rectTransform.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        _dragGhost.sprite = GetComponent<Image>().sprite;
        _dragGhost.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _rootCanvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out var localPos
        );
        _dragGhost.rectTransform.anchoredPosition = localPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_dragGhost != null)
            Destroy(_dragGhost.gameObject);
    }
}
