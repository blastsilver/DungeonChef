using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DungeonChef
{
    public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        Item                  m_item;
        UnityEngine.UI.Button m_uiButton;
        

        public Item Item { get { return m_item; } set { Insert(value); } }
        public bool IsActive { get { return m_uiButton.interactable; } set { m_uiButton.interactable = value; } }
        public bool IsDragging { get { return InventoryDrag.Enabled; } protected set { SetDragState(value); } }

        void Start()
        {
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
                if (hit.transform.tag == "Cauldron" && GetComponent<Cauldron>().Insert(this))
                {
                    Remove();
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



        public void Remove() { m_item = null; IsActive = false; }
        public void Insert(Item item) { m_item = item; IsActive = true; }
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