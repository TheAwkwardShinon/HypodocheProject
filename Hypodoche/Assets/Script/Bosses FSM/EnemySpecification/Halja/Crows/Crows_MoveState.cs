using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Crows_MoveState : MoveState
    {

        private Crows _crow;
        public Crows_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Crows crow) : base(entity, stateMachine, animationName, entityData)
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
            if (_isDetectingWall)
            {
                _crow.GetIdleState().setFlipAfterIdle(true);
                _stateMachine.ChangeState( _crow.GetIdleState());
            }
            else{
                _crow.Movecrow();
            }
        }
    }
}
