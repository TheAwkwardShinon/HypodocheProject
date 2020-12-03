using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class MoveState : State
    {
        #region Variables
        protected D_Entity _entityData;
        protected bool _isDetectingWall;
        protected bool _isDetectingPlayer;
        #endregion

        #region Methods
        public MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData)
            : base(entity, stateMachine, animationName)
        {
            _entityData = entityData;
        }

        public override void Enter()
        {
            base.Enter();

            _isDetectingWall = _entity.checkWall();
            _isDetectingPlayer = _entity.isPlayerInAggroRange();
            _entity.setDirection();
     
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _isDetectingWall = _entity.checkWall();
            _isDetectingPlayer = _entity.isPlayerInAggroRange();
        }
    }
    #endregion
}
