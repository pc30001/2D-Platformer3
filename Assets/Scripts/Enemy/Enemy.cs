using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private WayPoint[] _wayPoints;
    [SerializeField] private float _speedX = 1;

    private Rigidbody2D _rigibody;
    private bool _isTurnRight = true;
    private int _wayPointIndex;
    private Transform _target;
    [SerializeField] private float _maxSqrDistance = 0.1f;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _target = _wayPoints[_wayPointIndex].transform;
    }

    private void FixedUpdate()
    {
        Move();

        if (IsTargetReached())
            ChangeTarget();
    }

    private void Move()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, _target.position, _speedX * Time.fixedDeltaTime);
        _rigibody.MovePosition(newPosition);
    }

    private bool IsTargetReached()
    {
        float sqrDistance = (transform.position - _target.position).sqrMagnitude;
        return sqrDistance < _maxSqrDistance;
    }

    private void ChangeTarget()
    {
        _wayPointIndex = ++_wayPointIndex % _wayPoints.Length;
        _target = _wayPoints[_wayPointIndex].transform;

        if ((transform.position.x < _target.position.x && _isTurnRight == false)
         || (transform.position.x > _target.position.x && _isTurnRight))
        {
            _isTurnRight = !_isTurnRight;
            transform.Flip();
        }
    }


}
