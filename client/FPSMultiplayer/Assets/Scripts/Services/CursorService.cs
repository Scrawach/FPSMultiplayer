using UnityEngine;

namespace Services
{
    public class CursorService
    {
        public void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}