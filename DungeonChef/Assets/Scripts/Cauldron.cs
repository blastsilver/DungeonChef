using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonChef
{
    public class Cauldron : MonoBehaviour
    {
        public Inventory      Inventory;
        public RecipeBook     RecipeBook;
        public Animator       RecipeAnimator;
        public Animator       ChefArmsAnimator;
        public Animator       ChefBodyAnimator;
        public ParticleSystem IngredientAnimation;
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
            if (IsClipPlaying("MealFinished"))
            {
                RecipeAnimator.SetBool("isMealFinished", false);
            }

            if (IsClipPlaying("Saltbae", ChefArmsAnimator)) ChefArmsAnimator.SetBool("isCooking", false);
            if (IsClipPlaying("Saltbae", ChefBodyAnimator)) ChefBodyAnimator.SetBool("isCooking", false);
        }

        void CheckRecipe()
        {
            if (m_slots.Count == 3)
            {
                Inventory.AddItem(CreateRecipeItem());
                m_slots.Clear();
                RecipeAnimator.SetBool("isMealFinished", true);

            } else IngredientAnimation.Emit(100);


            ChefArmsAnimator.SetBool("isCooking", true);
            ChefBodyAnimator.SetBool("isCooking", true);
        }

        bool IsClipPlaying(string name)
        {
            return IsClipPlaying(name, RecipeAnimator);
        }

        bool IsClipPlaying(string name, Animator anim)
        {
            return anim.GetCurrentAnimatorStateInfo(0).IsName(name);
        }

        Item CreateRecipeItem(int i) { return new Item(RecipeBook.Recipies[i]); }
        Item CreateIngredientItem(int i) { return new Item(RecipeBook.Ingredients[i]); }
        public Item CreateRecipeItem() { return CreateRecipeItem(Random.Range(0, this.RecipeBook.Recipies.Count)); }
        public Item CreateIngredientItem() { return CreateIngredientItem(Random.Range(0, this.RecipeBook.Ingredients.Count)); }

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