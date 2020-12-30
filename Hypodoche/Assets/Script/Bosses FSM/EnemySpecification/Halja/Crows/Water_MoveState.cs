using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Water_MoveState : MoveState
    {

        private WaterCrow _crow;
        public Water_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, WaterCrow crow) : base(entity, stateMachine, animationName, entityData)
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
               Debug.Log("[WaterCrow] change state moveState -> unbreakableBond"+Time.time);
                //_stateMachine.ChangeState(_crow._unbreakableBond);
            }
            if (_isDetectingWall)
            {
                _crow._IdleState.setFlipAfterIdle(true);
                Debug.Log("[WaterCrow] change state moveState -> idleState "+Time.time);
                _stateMachine.ChangeState( _crow._IdleState);
            }
            else{
                _crow.Move(_entityData.movementSpeed);
            }
        }
    }
}