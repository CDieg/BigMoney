using UnityEngine;

public class CursorLock : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Press Escape key to apply no locking to the Cursor
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else Cursor.lockState = CursorLockMode.Locked;

        }
    }

    private void OnGUI()
    {
       // GUI

    }
}
