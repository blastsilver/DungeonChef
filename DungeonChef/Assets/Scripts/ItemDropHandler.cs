using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData e)
    {
        RectTransform rect = transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
        {
            Debug.Log("drop");
        }
    }
}
