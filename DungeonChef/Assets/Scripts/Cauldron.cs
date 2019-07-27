using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonChef
{
    public class Cauldron : MonoBehaviour
    {
        public Inventory    Inventory;
        public RecipeBook   RecipeBook;
        List<InventorySlot> m_slots = new List<InventorySlot>();

        void Start()
        {
            //Inventory.AddItem(CreateIngredientItem(0));
            //Inventory.AddItem(CreateIngredientItem(1));
            //Inventory.AddItem(CreateIngredientItem(2));
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Inventory.AddItem(CreateIngredientItem());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Inventory.AddItem(CreateRecipeItem());
            }
        }

        void CheckRecipe()
        {
            if (m_slots.Count == 3)
            {
                Inventory.AddItem(CreateRecipeItem());
                m_slots.Clear();
            }
        }

        void PlayAnimation()
        {

        }

        Item CreateRecipeItem() { return CreateRecipeItem(Random.Range(0, this.RecipeBook.Recipies.Count)); }
        Item CreateRecipeItem(int i) { return new Item(RecipeBook.Recipies[i]); }
        Item CreateIngredientItem() { return CreateIngredientItem(Random.Range(0, this.RecipeBook.Ingredients.Count)); }
        Item CreateIngredientItem(int i) { return new Item(RecipeBook.Ingredients[i]); }

        public bool Insert(InventorySlot slot)
        {
            if (slot.Item.IsIngredient)
            {
                m_slots.Add(slot);
                CheckRecipe();
                return true;
            }
            return false;
        }
    }
}