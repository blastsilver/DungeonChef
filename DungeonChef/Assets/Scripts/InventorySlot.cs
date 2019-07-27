using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DungeonChef
{
    public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        Item                  m_item;
        Inventory             m_inventory;
        UnityEngine.UI.Image  m_uiImage;
        UnityEngine.UI.Button m_uiButton;

        public Item Item { get { return m_item; } set { Insert(value); } }
        public bool IsActive { get { return m_uiButton.interactable; } set { m_uiButton.interactable = value; } }
        public bool IsDragging { get { return InventoryDrag.Enabled; } protected set { SetDragState(value); } }

        void Start()
        {
            m_inventory = GetComponentInParent<Inventory>();

            m_uiImage = GetComponent<UnityEngine.UI.Image>();
            m_uiImage.sprite = null;

            m_uiButton = GetComponent<UnityEngine.UI.Button>();
            m_uiButton.interactable = false;
        }


        void SetDragState(bool state)
        {
            InventoryDrag.Enabled = state;
            m_uiButton.interactable = !state;
        }

        bool CheckDragNDrop()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Cauldron" && hit.transform.GetComponent<Cauldron>().Insert(this))
                {
                    Remove();
                    DisableDragNDrop();
                    Debug.Log("Drop here & update inventory");

                    return true;
                }
            }

            return false;
        }

        void EnableDragNDrop()
        {
            IsDragging = true;
            InventoryDrag.Sprite = GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        }

        void DisableDragNDrop()
        {
            IsDragging = false;
            InventoryDrag.LocalPosition = Vector3.zero;
        }

        public void Remove()
        {
            m_item = null;
            IsActive = false;
            m_uiImage.color = new Color(0, 0, 0, 0);
            m_uiImage.sprite = null;
            m_inventory.RemoveItem(Item);
        }

        public void Insert(Item item)
        {
            m_item = item;
            IsActive = true;
            m_uiImage.color = Color.white;
            m_uiImage.sprite = m_item.Sprite;
        }
        public void OnDrag(PointerEventData e)
        {
            if (IsDragging)
            {
                InventoryDrag.Position = Input.mousePosition;
            }
        }
        public void OnDrop(PointerEventData e)
        {
            if (IsDragging && !CheckDragNDrop())
            {
                DisableDragNDrop();
            }
        }
        public void OnEndDrag(PointerEventData e)
        {
            if (IsDragging && !CheckDragNDrop())
            {
                DisableDragNDrop();
            }
        }
        public void OnBeginDrag(PointerEventData e)
        {
            if (IsActive && !IsDragging)
            {
                EnableDragNDrop();
            }
        }
    }
}