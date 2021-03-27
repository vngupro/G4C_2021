using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMouseCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D cursorTalk;
    // Start is called before the first frame update
    void Start()
    {
        SetInitialCursor();
    }

    public void ChangeCursorOnNPC()
    {
        Cursor.SetCursor(cursorTalk, Vector2.zero, CursorMode.Auto);
    }

    public void SetInitialCursor()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
