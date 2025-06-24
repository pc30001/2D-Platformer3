using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50;
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string GROUND_TAG = "Ground";

    [SerializeField] private float _speedX = 1;
    [SerializeField] private float _speedY = 1;
    [SerializeField] private float _jumpForce = 500;

    private Rigidbody2D _rigibody;
    private float _direction;
    private float _verh;
    private bool _isJump;
    private bool _isGround;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        _direction = Input.GetAxis(HORIZONTAL_AXIS);
        _verh = Input.GetAxis(VERTICAL_AXIS);

        //if (_isGround && Input.GetKeyDown(KeyCode.W))
        //{
        //    _isJump = true;
        //}
    }

    private void FixedUpdate()
    {

        //_rigibody.velocity = new Vector2(_speedX * _direction * SPEED_COEFFICIENT * Time.fixedDeltaTime, _rigibody.velocity.y);
        //_rigibody.velocity = new Vector2(_speedY * _verh * SPEED_COEFFICIENT * Time.fixedDeltaTime, _rigibody.velocity.x);

        float moveX = _speedX * _direction * SPEED_COEFFICIENT * Time.fixedDeltaTime;
        float moveY = _speedY * _verh * SPEED_COEFFICIENT * Time.fixedDeltaTime;
        
        _rigibody.velocity = new Vector2(moveX, moveY);

        //if (_isJump)
        //{
        //    _rigibody.AddForce(new Vector2(0, _jumpForce));
        //    _isJump = false;
        //    _isGround = false;
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag(GROUND_TAG))
    //        _isGround = true;
    //}
}
