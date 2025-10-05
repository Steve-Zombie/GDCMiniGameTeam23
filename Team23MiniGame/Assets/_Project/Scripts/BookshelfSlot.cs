using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BookshelfSlot : MonoBehaviour
{
    public Sprite curr_sprite;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Sprite sprite = dropped.GetComponent<Image>().sprite;
        curr_sprite = sprite;

    }
}
