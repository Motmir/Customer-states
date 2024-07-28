using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVisualControler : MonoBehaviour
{
    public Texture2D cursorArrow;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Mouse start");
        Vector2 cursorOffset = new Vector2(cursorArrow.width / 2, 0);
        Cursor.SetCursor(cursorArrow, cursorOffset, CursorMode.ForceSoftware);
    }
}
