using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(GroudDetector), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator), typeof(CollisionHandler))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _mover;
    private GroudDetector _groudDetector;
    private PlayerAnimator _animator;
    private CollisionHandler _collisionHandler;

    private Finish _finish;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groudDetector = GetComponent<GroudDetector>();
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<PlayerAnimator>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.FinishReached += OnFinishReached;
    }

    private void OnDisable()
    {
        _collisionHandler.FinishReached -= OnFinishReached;
    }

    private void FixedUpdate()
    {
        _animator.SetSpeedX(_inputReader.Direction);

        if (_inputReader.Direction != 0)
            _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groudDetector.IsGround)
            _mover.Jump();

        if (_inputReader.GetIsInteract() && _finish != null)
            _finish.Interact();
    }
    private void OnFinishReached(Finish finish)
    {
        _finish = finish; 
    }
}
