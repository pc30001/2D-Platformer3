using System;
using System.Collections.Generic;

abstract class StateMachine
{
    protected State CurrentState;
    protected Dictionary<Type, State> States;

    public void Update()
    {
        if (CurrentState == null)
            return;

        CurrentState.Update();
        CurrentState.TryTransit();
    }

    public void ChangeState<Tstate>() where Tstate : State
    {
        if (CurrentState != null && CurrentState.GetType() == typeof(Tstate))
            return;

        if (States.TryGetValue(typeof(Tstate), out State newState))
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}

