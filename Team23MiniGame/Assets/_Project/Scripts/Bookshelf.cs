using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public BookshelfSlot[] slots;
    private Item[] solution;

    // clears the shelf of items
    public void ClearShelf()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].curr_item = null;
        }
    }

    // takes a generated puzzle sequence
    // puts it in the shelf and saves it as a solution
    public void UpdateShelf(Item[] items)
    {
        solution = items;
        if (items.Length == slots.Length)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].curr_item = items[i];
            }
        }
    }

    // returns whether all slots match the saved solution
    public bool Evaluate()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].curr_item != solution[i]) {
                return false;
            }
        }
        return true;
    }
}
