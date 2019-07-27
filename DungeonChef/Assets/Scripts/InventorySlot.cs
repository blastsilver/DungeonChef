using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    UnityEngine.UI.Button m_button;

    void Start()
    {
        m_button = GetComponent<UnityEngine.UI.Button>();
    }

    void CheckDragNDrop(PointerEventData e)
    {
        List<RaycastResult> hits = new List<RaycastResult>();
        EventSystem.current.RaycastAll(e, hits);

        Debug.Log("Hello " + hits.Count + " boys!");

        for (int i = 0; i < hits.Count; i++)
        {
            if (hits[i].gameObject.tag == "Cauldron")
            {
                Debug.Log("Drop here & update inventory");
                return;
            }
        }
    }

    void EnableDragNDrop()
    {
        m_button.interactable = false;
        InventoryDrag.Enabled = true;
        InventoryDrag.Sprite = GetComponentInChildren<UnityEngine.UI.Image>().sprite;
    }

    void DisableDragNDrop()
    {
        m_button.interactable = true;
        InventoryDrag.Enabled = false;
        InventoryDrag.LocalPosition = Vector3.zero;
    }


    public void OnDrag(PointerEventData e)
    {
        InventoryDrag.Position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData e)
    {
        DisableDragNDrop();
        CheckDragNDrop(e);
    }

    public void OnEndDrag(PointerEventData e)
    {
        DisableDragNDrop();
        CheckDragNDrop(e);
    }
    public void OnBeginDrag(PointerEventData e)
    {
        EnableDragNDrop();
    }
}