using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50;

    [SerializeField] private float _speedX = 1;
    [SerializeField] private float _jumpForce = 500;

    private Rigidbody2D _rigibody;
    private bool _isTurnRight = true;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigibody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move(float direction)
    {
        _rigibody.velocity = new Vector2(_speedX * direction * SPEED_COEFFICIENT * Time.fixedDeltaTime, _rigibody.velocity.y);
    }

    public void Move(Transform target)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, _speedX * Time.fixedDeltaTime);
        _rigibody.MovePosition(newPosition);
    }
}