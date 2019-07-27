using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonChef
{
    public class Adventurer : MonoBehaviour
    {
        public string name = "";
        public float health = 10.0f;
        TextMesh m_text;

        void Start()
        {
            m_text = GetComponentInChildren<TextMesh>();
        }

        void Update()
        {
            float ihealth = Mathf.Round(health);

            if (ihealth <= 0)
            {
                Destroy(transform.parent.gameObject, 0);
                FindObjectOfType<RoundManager>().KillAdventurer();
            }
            m_text.text = name + "\n" + Mathf.Max(0, ihealth).ToString();
        }

        public bool Feed(InventorySlot slot)
        {
            if (slot.Item.IsRecipe)
            {
                health += Random.Range(-3.0f, 3.0f);
                return true;
            }
            return false;
    }
    }
}