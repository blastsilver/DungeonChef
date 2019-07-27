using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonChef
{
    [CreateAssetMenu(fileName = "New Recipe Book", menuName = "DungeonChef/Recipe Book")]
    public class RecipeBook : ScriptableObject
    {
        public List<Ingredient> Ingredients = new List<Ingredient>();
        [HideInInspector]
        public List<Recipe> Recipies = new List<Recipe>();

        public Recipe Search(Ingredient i1, Ingredient i2, Ingredient i3)
        {
            int id = i1.ID | i2.ID | i3.ID;
            foreach (Recipe recipe in Recipies)
            {
                if (recipe.ID == id)
                {
                    return recipe;
                }
            }
            return null;
        }
    }
}
