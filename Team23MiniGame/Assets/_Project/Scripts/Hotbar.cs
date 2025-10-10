using System;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    //[SerializeField] private DraggableItem[] itemList;

    // show or hide the hotbar
    public void Show(bool toShow)
    {
        gameObject.SetActive(toShow);
    }
}
