using UnityEngine;
using System.Collections;

namespace DungeonChef
{
    public class Item
    {
        public int        ID;
        public Recipe     Recipe;
        public Ingredient Ingredient;

        public bool IsRecipe { get { return Ingredient == null; } }
        public bool IsIngredient { get { return Recipe == null; } }
    }
}