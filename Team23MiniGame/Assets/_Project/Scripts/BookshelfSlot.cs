using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
public class BookshelfSlot : MonoBehaviour, IDropHandler
{
    public Item curr_item;

    // recieve item when dropped in
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Debug.Log(dropped);
        DraggableItem dItem = dropped.GetComponent<DraggableItem>();
        curr_item = dItem.Item;
        UpdateSprite(curr_item.sprite);
    }

    public void UpdateSprite(Sprite sprite)
    {
        if (sprite == null) return;

        gameObject.GetComponent<Image>().sprite = sprite;
    }
}
