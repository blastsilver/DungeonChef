using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace DungeonChef
{
    public class RoundManager : MonoBehaviour
    {
        Cauldron     m_cauldron;
        Inventory    m_inventory;
        Adventurer[] m_adventurers;
        public int m_aliveAdventures;

        public List<string> names = new List<string>();

        // Use this for initialization
        void Start()
        {
            m_cauldron = FindObjectOfType<Cauldron>();
            m_inventory = FindObjectOfType<Inventory>();
            m_adventurers = FindObjectsOfType<Adventurer>();
            m_aliveAdventures = m_adventurers.Length;

            foreach (Adventurer a in m_adventurers)
            {
                a.tagname = names[Random.Range(0, names.Count)];
                a.UpdateText();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
                Application.Quit();

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                NextRound();
            }

            if (m_aliveAdventures <= 0)
            {
                SceneManager.LoadScene(0);
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
                m_adventurers[i].Damage(Random.Range(0, 3));
            }
        }

        public void KillAdventurer()
        {
            m_aliveAdventures--;
        }
    }
}