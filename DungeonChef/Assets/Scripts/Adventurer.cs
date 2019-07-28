using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonChef
{
    public class Adventurer : MonoBehaviour
    {
        public float          walkSpeed = 2.0f;
        public float          walkDelay = 8.0f;
        public Animator       animator = null;
        public Animator       bloodAnimator = null;
        public SpriteRenderer itemRenderer = null;
        public string         tagname = "";
        public float          health = 10.0f;
        TextMesh              m_text;
        public Item           Item;
        bool healthUpdated = false;
        float delay = 0;

        private int  DeathId { get { return animator.GetInteger("DeathId"); } set { animator.SetInteger("DeathId", value); } }
        private bool IsIdle { get { return IsClipPlaying("Idle"); } set { animator.SetBool("isIdle", value); } }
        private bool IsSitting { get { return IsClipPlaying("Sitting"); } set { animator.SetBool("isSitting", value); } }
        private bool IsStanding { get { return IsClipPlaying("Standing"); } set { animator.SetBool("isStanding", value); } }
        private bool IsHealthUp { get { return IsClipPlaying("HealthUp"); } set { animator.SetBool("isHealthUp", value); } }
        private bool IsHealthDown { get { return IsClipPlaying("HealthDown"); } set { animator.SetBool("isHealthDown", value); } }
        private bool IsWalkingLeft { get { return IsClipPlaying("WalkingLeft"); } set { animator.SetBool("isWalkingLeft", value); } }
        private bool IsWalkingRight { get { return IsClipPlaying("WalkingRight"); } set { animator.SetBool("isWalkingRight", value); } }
        private bool IsOffscreenDeath { get { return IsClipPlaying("BloodSplash", bloodAnimator); } set { bloodAnimator.SetBool("isOffscreenDeath", value); } }

        void Start()
        {
            m_text = GetComponentInChildren<TextMesh>();
            UpdateText();
            HideItem();

            IsIdle = true;
        }

        void Update()
        {
            if (IsOffscreenDeath) IsOffscreenDeath = false;

            if (IsIdle)
            {
                float ihealth = Mathf.Round(health);

                if (ihealth <= 0) Kill();
                //m_text.text = tagname + "\n" + Mathf.Max(0, ihealth).ToString();

            }
            else if (IsHealthUp) IsHealthUp = false;
            else if (IsHealthDown) IsHealthDown = false;
            else if (IsStanding)
            {
                HideItem();
                IsStanding = false;
                IsWalkingRight = true;
                delay = walkDelay;
            }
            else if (IsWalkingRight)
            {
                if (healthUpdated) return;

                Vector3 scale = transform.parent.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.parent.localScale = scale;

                delay -= Time.deltaTime;
                transform.parent.position += Vector3.left * Time.deltaTime * walkSpeed;
                if (delay <= 0.0f)
                {
                    delay = walkDelay;
                    IsWalkingRight = false;
                    healthUpdated = true;
                    Damage(Random.Range(0, 3));
                    if (health > 0.0f)
                    {
                        IsWalkingLeft = true;
                    }
                    else
                    {
                        Kill();
                        IsOffscreenDeath = true;
                    }
                }
            }
            else if (IsWalkingLeft && delay > 0.0f)
            {
                delay -= Time.deltaTime;

                Vector3 scale = transform.parent.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.parent.localScale = scale;

                transform.parent.position += Vector3.right * Time.deltaTime * walkSpeed;

                if (delay <= 0.0f)
                {
                    delay = 0.0f;
                    healthUpdated = false;
                    IsWalkingLeft = false;
                    IsSitting = true;
                }
            }
            else if (IsSitting)
            {
                IsSitting = false;
                IsIdle = true;
                if (Item != null) ShowItem();
            }
        }

        void Kill()
        {
            Destroy(transform.parent.gameObject, 0);
            FindObjectOfType<RoundManager>().KillAdventurer(this);
        }

        bool IsClipPlaying(string name)
        {
            return IsClipPlaying(name, animator);
        }

        bool IsClipPlaying(string name, Animator anim)
        {
            return anim.GetCurrentAnimatorStateInfo(0).IsName(name);
        }

        public bool Feed(InventorySlot slot)
        {
            if (slot.Item.IsRecipe)
            {
                float effect = Random.Range(-3.0f, 4.0f);
                while (Mathf.Round(effect) == 0) effect = Random.Range(-3.0f, 4.0f);

                if (effect > 0.0f) IsHealthUp = true; else IsHealthDown = true;

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
        }

        public void ShowItem()
        {
            itemRenderer.enabled = true;
            itemRenderer.sprite = Item.Sprite;
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

        public void NextRound()
        {
            IsStanding = true;
        }
    }
}