using UnityEngine;
using System.Collections;

namespace DungeonChef
{
    public class RoundManager : MonoBehaviour
    {
        Cauldron     m_cauldron;
        Inventory    m_inventory;
        Adventurer[] m_adventurers;

        // Use this for initialization
        void Start()
        {
            m_cauldron = FindObjectOfType<Cauldron>();
            m_inventory = FindObjectOfType<Inventory>();
            m_adventurers = FindObjectsOfType<Adventurer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                NextRound();
            }
        }

        public void NextRound()
        {
            int amount = Random.Range(1, 3);
            for (int i = 0; i < amount; i++)
            {
                m_inventory.AddItem(m_cauldron.CreateIngredientItem());
            }

            for (int i = 0; i < m_adventurers.Length; i++)
            {
                m_adventurers[i].health -= Random.Range(1, 3);
            }
        }
    }
}