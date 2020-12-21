using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Crows_idleState : IdleState
    {
        private Crows _crow;
        public Crows_idleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_IdleState idleData, Crows crow) : base(entity, stateMachine, animationName, idleData)
        {
            _crow = crow;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
             if (_isIdleTimeElapsed)
                _stateMachine.ChangeState(_crow.GetMoveState());
            
        }
    }
}
