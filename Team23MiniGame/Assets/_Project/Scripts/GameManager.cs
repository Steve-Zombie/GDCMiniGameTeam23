using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour, MinigameSubscriber
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<Item> avaliableItems;
    public Bookshelf bookshelf;
    public Hotbar hotbar;

    private List<Item> memeorizedSequence = new List<Item>();
    private List<Item> playerSequence = new List<Item>();

    public  TimerManager timerManager;

    void Awake()
    {
        MinigameManager.Subscribe(this);
        if (timerManager == null)
        {
            Debug.LogError("Timer Not Found");
        }
    }

    public void OnMinigameStart()
    {
        OnMemorizationStart();
        timerManager.StartTimers(0);
    }

    public void OnTimerEnd()
    {
        
    }

    void Start()
    {

    }


    void GenerateNewPuzzleSequence()
    {
        memeorizedSequence.Clear();
        playerSequence.Clear();

        List<int> usedIndexes = new List<int>();
        int count = bookshelf.slots.Length;

        while (memeorizedSequence.Count < count)
        {
            int randomIndex = Random.Range(0, avaliableItems.Count);
            if (!usedIndexes.Contains(randomIndex))
            {
                usedIndexes.Add(randomIndex);
                Debug.Log(usedIndexes.Count);
                memeorizedSequence.Add(avaliableItems[randomIndex]);
            }
        }
    }

    public void OnMemorizationStart()
    {
        Debug.Log("Memorization timer has Started.");
        GenerateNewPuzzleSequence();
        bookshelf.UpdateShelf(memeorizedSequence.ToArray());
        playerSequence.Clear();
        hotbar.Show(false);

    }
    public void OnMemorizationEnd()
    {

        Debug.Log("Memorization timer ended.");
        bookshelf.ClearShelf();
        hotbar.Show(true);
        playerSequence = new List<Item>(new Item[bookshelf.slots.Length]);

    }

    public void OnInputStart()
    {
       Debug.Log("Player input phase started.");
    }

    public void OnInputEnd()
    {
        hotbar.Show(false);
        Evaluate();
    }


    public void UpdatePlayerSequence(int slotIndex, Item selectedItem)
    {
        if ((slotIndex >= 0) && (slotIndex < playerSequence.Count))
        {
            playerSequence[slotIndex] = selectedItem;
        }
    }

    public void Evaluate()
    {
        bool correctMatch = true;

        for (int i = 0; i < memeorizedSequence.Count; i++)
        {
            if (playerSequence.Count <= i || playerSequence[i] != memeorizedSequence[i])
            {
                correctMatch = false;
                break;
            }
        }

        if (correctMatch)
        {
            Debug.Log("Player won!");
        }
        else
        {
            Debug.Log("Player lost!");
        }

    }
    
}
