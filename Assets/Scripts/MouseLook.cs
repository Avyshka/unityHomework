using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField] private RotationAxes _axes = RotationAxes.MouseXAndY;
    [SerializeField] private float _sensitivityHor = 5.0f;
    [SerializeField] private float _sensitivityVert = 5.0f;

    [SerializeField] private float _minimumVert = -45.0f;
    [SerializeField] private float _maximumVert = 45.0f;

    private float _rotationX = 0;

    private Vector3 _rotate = new Vector3();

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) {
            body.freezeRotation = true;
        }
    }

	void Update () 
    {
        if (_axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHor, 0);
        }
        else if (_axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);
            float rotationY = transform.localEulerAngles.y;
            _rotate.Set(_rotationX, rotationY, 0);
            transform.localEulerAngles = _rotate;
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);

            float delta = Input.GetAxis("Mouse X") * _sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            _rotate.Set(_rotationX, rotationY, 0);
            transform.localEulerAngles = _rotate;
        }
	}
}
