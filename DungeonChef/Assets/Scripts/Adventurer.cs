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
        public Item           Item;

        private int AnimationDeathId { get { return animator.GetInteger("DeathId"); } set { animator.SetInteger("DeathId", value); } }
        private bool AnimationIsIdle { get { return animator.GetBool("isIdle"); } set { animator.SetBool("isIdle", value); } }
        private bool AnimationIsHeal { get { return animator.GetBool("isHeal"); } set { animator.SetBool("isHeal", value); } }
        private bool AnimationIsDead { get { return animator.GetBool("isDead"); } set { animator.SetBool("isDead", value); } }
        private bool AnimationIsDamage { get { return animator.GetBool("isDamage"); } set { animator.SetBool("isDamage", value); } }
        private bool AnimationIsSitting { get { return animator.GetBool("isSitting"); } set { animator.SetBool("isSitting", value); } }
        private bool AnimationIsStanding { get { return animator.GetBool("isStanding"); } set { animator.SetBool("isStanding", value); } }
        private bool AnimationIsWalkingLeft { get { return animator.GetBool("isWalkingLeft"); } set { animator.SetBool("isWalkingLeft", value); } }
        private bool AnimationIsWalkingRight { get { return animator.GetBool("isWalkingRight"); } set { animator.SetBool("isWalkingRight", value); } }

        void Start()
        {
            m_text = GetComponentInChildren<TextMesh>();
            UpdateText();
            HideItem();

            AnimationIsIdle = true;
        }

        void Update()
        {
            float ihealth = Mathf.Round(health);

            if (ihealth <= 0)
            {
                Destroy(transform.parent.gameObject, 0);
                FindObjectOfType<RoundManager>().KillAdventurer(this);
            }
            //m_text.text = tagname + "\n" + Mathf.Max(0, ihealth).ToString();

            if (AnimationIsHeal)
            {
                if (AnimationIsIdle)
                {
                    AnimationIsIdle = false;
                }
                else
                {
                    AnimationIsIdle = true;
                    AnimationIsHeal = false;
                }
            }
            if (AnimationIsDamage)
            {
                if (AnimationIsIdle)
                {
                    AnimationIsIdle = false;
                }
                else
                {
                    AnimationIsIdle = true;
                    AnimationIsDamage = false;
                }
            }
        }

        public bool Feed(InventorySlot slot)
        {
            if (slot.Item.IsRecipe)
            {
                float effect = Random.Range(-3.0f, 4.0f);
                while (Mathf.Round(effect) == 0) effect = Random.Range(-3.0f, 4.0f);

                if (effect > 0.0f) AnimationIsHeal = true; else AnimationIsDamage = true;

                health += effect;
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
            Item = item;
            itemRenderer.sprite = Item.Sprite;
            ShowItem();
        }

        public void ShowItem()
        {
            itemRenderer.enabled = true;
        }

        public void HideItem()
        {
            itemRenderer.enabled = false;
        }

        public void RemoveItem()
        {
            Item = null;
            itemRenderer.sprite = null;
        }

        public void UpdateText()
        {
            float ihealth = Mathf.Round(health);
            if (m_text != null)
                m_text.text = tagname + "\n" + Mathf.Max(0, ihealth).ToString();
        }
    }
}