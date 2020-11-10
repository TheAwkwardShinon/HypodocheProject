using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class PlayerDetectState : State
    {


        #region Variables
        protected D_PlayerDetectState _playerDetectData;
        protected bool _isDetectingPlayer;
        #endregion

        #region Methods
        public PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_PlayerDetectState playerDetectData)
            : base(entity, stateMachine, animationName)
        {
            _playerDetectData = playerDetectData;
        }


        public override void Enter()
        {
            base.Enter();
            _isDetectingPlayer = _entity.isPlayerInAggroRange();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _isDetectingPlayer = _entity.isPlayerInAggroRange();
        }
        #endregion
    }
}
