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

            if(!_crow.IsIneluttable()){
                if(_isDetectingPlayer){
                    _stateMachine.ChangeState(_crow._playerDetect);
                }
            }
    
            if (_isDetectingWall)
            {
                _crow._IdleState.setFlipAfterIdle(true);
                _stateMachine.ChangeState( _crow._IdleState);
            }
            else{
                _crow.Move(_entityData.movementSpeed);
            }
        }
    }
}