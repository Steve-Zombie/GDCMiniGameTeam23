using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    private enum MinigameState
    {
        READY,
        PLAYING,
        SUCCESS,
        FAILURE
    }

    private MinigameState mstate = MinigameState.READY;

    public List<Item> availableItems;
    public Bookshelf bookshelf;

    private Item[] GenerateNewPuzzleSequence()
    {
        int count = bookshelf.slots.Length;
        Item[] res = new Item[count];

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, availableItems.Count);
            res[i] = availableItems[randomIndex];
        }

        return res;
    }

    public void OnMemorizationStart()
    {
        mstate = MinigameState.PLAYING;
        Item[] newSequence = GenerateNewPuzzleSequence();
        foreach (Item item in newSequence)
        {
            Debug.Log("Generated item: " + item.name);
        }
        bookshelf.UpdateShelf(newSequence);
    }
    
    public void Evaluate()
    {
        if (bookshelf.Evaluate())
        {
            mstate = MinigameState.SUCCESS;
        }
        else
        {
            mstate = MinigameState.FAILURE;
        }
    }

    public void ShowResults()
    {
        if(mstate == MinigameState.SUCCESS)
        {
            Debug.Log("You win!");
        }
        else if(mstate == MinigameState.FAILURE)
        {
            Debug.Log("You lose!");
        }
    }
}
