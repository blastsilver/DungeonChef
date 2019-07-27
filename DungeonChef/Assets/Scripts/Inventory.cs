using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonChef
{
    public class Inventory : MonoBehaviour
    {
        // variables
        List<Item>    items = new List<Item>();
        public int    totalSpace = 8;
        public Action OnInventoryItemChange;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool AddItem(Item item)
        {
            if (items.Count < totalSpace)
            {
                items.Add(item);
                OnInventoryItemChange?.Invoke();
                return true;
            }
            return false;
        }
        public bool RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                OnInventoryItemChange?.Invoke();
                return true;
            }
            return false;
        }
    }
}