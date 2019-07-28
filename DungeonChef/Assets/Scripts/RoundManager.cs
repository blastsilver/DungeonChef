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

        List<Adventurer> m_adventurers = new List<Adventurer>();
        public List<string> names = new List<string>();

        // Use this for initialization
        void Start()
        {

            m_cauldron = FindObjectOfType<Cauldron>();
            m_inventory = FindObjectOfType<Inventory>();

            var alist = FindObjectsOfType<Adventurer>();
            foreach (Adventurer a in alist)
            {
                a.tagname = names[Random.Range(0, names.Count)];
                a.UpdateText();
                m_adventurers.Add(a);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
                SceneManager.LoadScene(0);

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                NextRound();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && m_adventurers.Count > 0)
            {
                m_adventurers[0].PlayDeath();
            }

            if (m_adventurers.Count <= 0)
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Ingredient")
                    {
                        var adventurer = hit.transform.parent.GetComponent<Adventurer>();
                        if (adventurer.Item != null)
                        {
                            m_inventory.AddItem(adventurer.Item);
                            adventurer.RemoveItem();
                            adventurer.HideItem();
                        }
                    }
                }
            }
        }

        public void NextRound()
        {
            //int amount = Random.Range(1, 3);
            //for (int i = 0; i < amount; i++)
            //{

            //    m_inventory.AddItem(m_cauldron.CreateIngredientItem());
            //}

            for (int i = 0; i < m_adventurers.Count; i++)
            {
                if (Random.value > 0.5f) m_adventurers[i].AddItem(m_cauldron.CreateIngredientItem());
                else m_adventurers[i].RemoveItem();
                m_adventurers[i].NextRound();
            }
        }

        public void KillAdventurer(Adventurer adventurer)
        {
            m_adventurers.Remove(adventurer);
        }
    }
}