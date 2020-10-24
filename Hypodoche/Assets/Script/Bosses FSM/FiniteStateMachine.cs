using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State currentState { get; private set; }

    public void InitializeState(State initialState)
    {
        setState(initialState);
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        setState(newState);
        currentState.Enter();
    }

    public void setState(State state)
    {
        currentState = state;
    }
}
