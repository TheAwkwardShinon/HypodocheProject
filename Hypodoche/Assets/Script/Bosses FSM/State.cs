using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class State
    {
        #region Variables
        protected FiniteStateMachine _stateMachine;
        protected Entity _entity;
        protected float _startTime;
        protected string _animationName;
        #endregion



        #region Methods
        public State(Entity entity, FiniteStateMachine stateMachine, string animationName)
        {
            _entity = entity;
            _stateMachine = stateMachine;
            _animationName = animationName;
        }


        public virtual void Enter()
        {
            _startTime = Time.time;
            _entity._animator.SetBool(_animationName, true);
        }

        public virtual void Exit()
        {
            _entity._animator.SetBool(_animationName, false);
        }

        public virtual void Update()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }
        #endregion
    }
}
