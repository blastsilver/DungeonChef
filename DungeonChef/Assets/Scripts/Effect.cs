using UnityEngine;
using System.Collections;

namespace DungeonChef
{
    public enum Effect
    {
        EFFECT_NONE              =-1,
        EFFECT_DOMINANT_DAMAGE   = 1,
        EFFECT_DOMINANT_HEALING  = 2,
        EFFECT_RECESSIVE_DAMAGE  = 4,
        EFFECT_RECESSIVE_HEALING = 8,
    }
}