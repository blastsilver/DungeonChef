using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrag : MonoBehaviour
{
    static Transform            g_transform = null;
    static InventoryDrag        g_inventoryDrag = null;
    static UnityEngine.UI.Image g_image = null;

    void Start()
    {
        if (g_inventoryDrag == null)
        {
            g_inventoryDrag = this;
            g_transform = transform;
            g_image = GetComponent<UnityEngine.UI.Image>();

            g_image.enabled = false;
        }
    }


    public static bool Enabled { set { g_image.enabled = value; } }
    public static Sprite Sprite { set { g_image.sprite = value; } }
    public static Vector3 Position { set { g_transform.position = value; } }
    public static Vector3 LocalPosition { set { g_transform.localPosition = value; } }
}