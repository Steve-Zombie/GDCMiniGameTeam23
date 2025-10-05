using UnityEngine;
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
        Item item = dropped.GetComponent<Item>();
        curr_item = item;
        //gameObject.sprite = item.sprite;

    }
}
