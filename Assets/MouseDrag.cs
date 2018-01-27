using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    private float offsetX;
    private float offsetY;
    private Vector2 startPos;
    public void BeginDrag()
    {
        startPos = transform.position;
        offsetX = transform.position.x - Input.mousePosition.x;
        offsetY = transform.position.y - Input.mousePosition.y;
    }

    public void OnDrag()
    {
        transform.position = new Vector3(0 + Input.mousePosition.x, 0 + Input.mousePosition.y);
    }

    public void EndDrag()
    {
        transform.position = startPos;
    }


}
