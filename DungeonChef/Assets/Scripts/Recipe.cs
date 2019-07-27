using UnityEngine;
using System.Collections;

namespace DungeonChef
{
    [CreateAssetMenu(fileName = "New Recipe", menuName = "DungeonChef/Recipe")]
    public class Recipe : ScriptableObject
    {
        [HideInInspector]
        public int        ID;
        public float      Effect;
        public Sprite     Sprite;
        [HideInInspector]
        public Ingredient Ingredient1;
        [HideInInspector]
        public Ingredient Ingredient2;
        [HideInInspector]
        public Ingredient Ingredient3;
    }
}