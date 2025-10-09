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
        DraggableItem dItem = dropped.GetComponent<DraggableItem>();
        UpdateItem(dItem.Item);
    }

    public void UpdateItem(Item item)
    {
        if (item == null)
        {
            Debug.Log("NULLING " + name);
            curr_item = null;
            gameObject.GetComponent<Image>().sprite = null;
            return;
        }

        curr_item = item;
        gameObject.GetComponent<Image>().sprite = item.sprite;
    }
}
