using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class PlayerDetectState : State
    {


        #region Variables
        protected D_Entity _entityData;
        protected bool _isDetectingPlayer;
        protected Transform _playerPosition;
        #endregion

        #region Methods
        public PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData)
            : base(entity, stateMachine, animationName)
        {
            _entityData = entityData;
        }


        public override void Enter()
        {
            base.Enter();
            _playerPosition = _entity.isPlayerInAggroRange();
            _isDetectingPlayer = _playerPosition == null ? false : true;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _playerPosition = _entity.isPlayerInAggroRange();
            _isDetectingPlayer = _playerPosition == null ? false : true;
        }
        #endregion
    }
}
