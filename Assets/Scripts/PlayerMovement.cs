using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _jumpForce = 100.0f;

    private Vector3 _movement = new Vector3();
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update () 
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        _movement.Set(deltaX, 0, deltaZ);
        _movement = Vector3.ClampMagnitude(_movement, _speed);

        _movement *= Time.deltaTime;
        transform.Translate(_movement);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        //if (_rigidbody.IsSleeping()) { 
        //    _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
        //}
        if (_rigidbody.velocity.y == 0)
        {
            _rigidbody.velocity = Vector3.up * _jumpForce * Time.deltaTime;
        }
    }
}
