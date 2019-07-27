using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int    totalSpace = 8;
    public Action OnInventoryItemChange;
    List<InventoryItem> items = new List<InventoryItem>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
        OnInventoryItemChange?.Invoke();
    }
    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
        OnInventoryItemChange?.Invoke();
    }
}
