using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour
{
    public Texture2D customCursor;

    void Start()
    {
        Cursor.SetCursor(customCursor, new Vector2(8,8), CursorMode.Auto);
    }

    void Update()
    {
        
    }
}
