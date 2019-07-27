using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData e)
    {
        
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData e)
    {
        transform.localPosition = Vector3.zero;
    }
}
