using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class FiniteStateMachine
    {
        #region Variables
        public State _currentState { get; private set; }
        #endregion

        #region Getter and Setter
        public void setState(State state)
        {
            _currentState = state;
        }
        #endregion

        #region Methods
        public void InitializeState(State initialState)
        {
            setState(initialState);
            _currentState.Enter();
        }

        public void ChangeState(State newState)
        {
            _currentState.Exit();
            setState(newState);
            _currentState.Enter();
        }
        #endregion
    }
}
