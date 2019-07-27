using UnityEngine;
using System.Collections;

namespace DungeonChef
{
    [CreateAssetMenu(fileName = "New Ingredient", menuName = "DungeonChef/Ingredient")]
    public class Ingredient : ScriptableObject
    {
        [HideInInspector]
        public int    ID;
        [HideInInspector]
        public Effect Effect;
        public Sprite Sprite;
    }
}