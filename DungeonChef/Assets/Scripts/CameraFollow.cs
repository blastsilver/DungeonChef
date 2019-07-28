using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 maxOffset = new Vector2(1, 1);

    Vector3 prev;

    void Start()
    {
        prev = transform.localPosition;
    }

    void Update()
    {
        float x = ((Input.mousePosition.x / Screen.width) - 0.5f) * 2.0f;
        float y = ((Input.mousePosition.y / Screen.height) - 0.5f) * 2.0f;

        transform.localPosition = prev + new Vector3(-x, y, 0) * 0.1f;
    }
}