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
            if(Time.time >=_crow._timer + _crow.unbreakableBond){
                 Debug.Log("[WaterCrow] change state IdleState -> unbreakableBond"+Time.time);
               // _stateMachine.ChangeState(_crow._unbreakableBond);
            }
             if (_isIdleTimeElapsed){
                 Debug.Log("[WaterCrow] change state idleState-> MoveState "+Time.time);
                _stateMachine.ChangeState(_crow._MoveState);
             }
            
        }
    }
}