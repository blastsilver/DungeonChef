using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonChef
{
    public class Adventurer : MonoBehaviour
    {
        public Animator       animator = null;
        public SpriteRenderer itemRenderer = null;
        public string         tagname = "";
        public float          health = 10.0f;
        TextMesh              m_text;
        Item                  m_item;

        void Start()
        {
            m_text = GetComponentInChildren<TextMesh>();
            UpdateText();
        }

        void Update()
        {
            float ihealth = Mathf.Round(health);

            if (ihealth <= 0)
            {
                Destroy(transform.parent.gameObject, 0);
                FindObjectOfType<RoundManager>().KillAdventurer();
            }
            //m_text.text = tagname + "\n" + Mathf.Max(0, ihealth).ToString();
        }

        public bool Feed(InventorySlot slot)
        {
            if (slot.Item.IsRecipe)
            {
                health += Random.Range(-3.0f, 4.0f);
                UpdateText();
                return true;
            }
            return false;
        }

        public void Damage(float n)
        {
            health -= n;
            UpdateText();
        }

        public void AddItem(Item item)
        {
            m_item = item;
            itemRenderer.sprite = m_item.Sprite;
        }

        public void ShowItem()
        {
            itemRenderer.enabled = true;
        }

        public void HideItem()
        {
            itemRenderer.enabled = false;
        }

        public void UpdateText()
        {
            float ihealth = Mathf.Round(health);
            if (m_text != null)
                m_text.text = tagname + "\n" + Mathf.Max(0, ihealth).ToString();
        }
    }
}