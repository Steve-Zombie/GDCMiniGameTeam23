using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public BookshelfSlot[] slots;


    void ClearShelf()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].curr_sprite = null;
        }
    }

    Sprite[] GetCurrentSequence()
    {
        Sprite[] result = new Sprite[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            result[i] = slots[i].curr_sprite;
        }
        return result;
    }

    void UpdateShelf(Sprite[] sprites)
    {
        if (sprites.Length == slots.Length)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].curr_sprite = sprites[i];
            }
        }
    }

}
