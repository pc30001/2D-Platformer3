using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(GroudDetector), typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover mover;
    private GroudDetector _groudDetector;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groudDetector = GetComponent<GroudDetector>();
        mover = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
            mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groudDetector.IsGround)
            mover.Jump();
    }
}
