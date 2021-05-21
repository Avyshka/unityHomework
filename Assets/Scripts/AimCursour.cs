using UnityEngine;

public class AimCursour : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth * .5f;
        float posY = _camera.pixelHeight * .5f;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
