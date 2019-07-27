using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonChef
{
    public class Inventory : MonoBehaviour
    {
        // variables
        public int    totalSpace = 8;
        public Action OnInventoryItemChange;
        public int             m_count = 0;
        InventorySlot[] m_slots = null;

        void Awake()
        {
            m_slots = GetComponentsInChildren<InventorySlot>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool AddItem(Item item)
        {
            if (m_count < totalSpace)
            {
                for (int i = 0; i < m_slots.Length; i++)
                {
                    if (m_slots[i].Item == null)
                    {
                        m_count++;
                        //if (i == m_count) m_count++;
                        m_slots[i].Insert(item);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool RemoveItem(Item item)
        {
            if (m_count > 0)
            {
                m_count--;
                return true;
            }
            return false;
        }
    }
}