using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonChef
{
    public class Cauldron : MonoBehaviour
    {
        public RecipeBook   RecipeBook;
        List<InventorySlot> m_slots = new List<InventorySlot>();

        void CheckRecipe()
        {

        }


        public bool Insert(InventorySlot slot)
        {
            if (slot.Item.IsIngredient)
            {
                m_slots.Add(slot);
                return true;
            }
            return false;
        }
    }
}