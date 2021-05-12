using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float _speed = 6.0f;

    private Vector3 _movement = new Vector3();

	void Update () 
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        _movement.Set(deltaX, 0, deltaZ);
        _movement = Vector3.ClampMagnitude(_movement, _speed);

        _movement *= Time.deltaTime;
        transform.Translate(_movement);

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {

    }
}
