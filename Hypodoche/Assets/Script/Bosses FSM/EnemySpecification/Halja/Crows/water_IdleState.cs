using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Water_idleState : IdleState
    {
        private WaterCrow _crow;
        public Water_idleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_IdleState idleData, WaterCrow crow) : base(entity, stateMachine, animationName, idleData)
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
            _crow.setPlayerPosition(_crow.isPlayerInAggroRange());
             if (_isIdleTimeElapsed){
                _stateMachine.ChangeState(_crow._MoveState);
             }
            
        }
    }
}