using UnityEngine;

class WayPointReachedTransition : ReachedTransition
{

    public WayPointReachedTransition(StateMachine stateMachine, IMoveState moveState, float maxSqrDistance, Transform transform) :
                base(stateMachine, moveState, maxSqrDistance, transform)
    { }

    public override void Transit()
    {
        base.Transit();
        StateMachine.ChangeState<IdleState>();
    }
}

class ReachedTransition : Transition
{
    private IMoveState _moveState;
    private float _maxSqrDistance = 0.44f;
    private Transform _transform;

    public ReachedTransition(StateMachine stateMachine, IMoveState moveState, float maxSqrDistance, Transform transform) : base(stateMachine)
    {
        _moveState = moveState;
        _maxSqrDistance = maxSqrDistance;
        _transform = transform;
    }

    public override bool IsNeedTransit()
    {
        float sqrDistance = (_transform.position - _moveState.Target.position).sqrMagnitude;

        return sqrDistance < _maxSqrDistance;
    }
}

class TargetReachedTransition : ReachedTransition
{

    public TargetReachedTransition(StateMachine stateMachine, IMoveState moveState, float maxSqrDistance, Transform transform) :
        base(stateMachine, moveState, maxSqrDistance, transform)
    { }

    public override void Transit()
    {
        base.Transit();
        StateMachine.ChangeState<IdleState>();
    }
}

