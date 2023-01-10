using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void OnValidate()
    {
        if (_speed < 0)
        {
            _speed = 10;
        }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        transform.Translate(movement * _speed * Time.fixedDeltaTime);
    }
}
