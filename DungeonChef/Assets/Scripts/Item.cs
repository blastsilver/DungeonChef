using UnityEngine;
using System.Collections;

namespace DungeonChef
{
    public class Item
    {
        public int        ID;
        public Recipe     Recipe;
        public Ingredient Ingredient;

        public Item(Recipe recipe) { Recipe = recipe; Sprite = recipe.Sprite; }
        public Item(Ingredient ingredient) { Ingredient = ingredient; Sprite = ingredient.Sprite; }

        public Sprite Sprite { get; protected set; }
        public bool IsRecipe { get { return Ingredient == null; } }
        public bool IsIngredient { get { return Recipe == null; } }
    }
}