using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonChef
{
    public class Adventurer : MonoBehaviour
    {
        public float health = 10.0f;

        public bool Feed(InventorySlot slot)
        {
            if (slot.Item.IsRecipe)
            {
                health += Random.Range(-5.0f, 5.0f);
                if (health < 0) Destroy(gameObject, 0);
                return true;
            }
            return false;
    }
    }
}