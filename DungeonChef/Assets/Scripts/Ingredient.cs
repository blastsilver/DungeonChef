using UnityEngine;
using System.Collections;

namespace DungeonChef
{
    [CreateAssetMenu(fileName = "New Ingredient", menuName = "DungeonChef/Ingredient")]
    public class Ingredient : ScriptableObject
    {
        public Effect effect;
        public Sprite sprite;
    }
}