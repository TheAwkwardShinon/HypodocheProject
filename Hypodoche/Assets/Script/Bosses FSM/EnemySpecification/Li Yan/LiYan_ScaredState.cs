using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche
{
    public class LiYan_ScaredState : ScaredState
    {
        #region Variables
        private LiYan _liYan;

        public LiYan_ScaredState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, LiYan liYan)
            : base(entity, stateMachine, animationName, entityData)
        {
            _liYan = liYan;
        }
        #endregion

        #region Methods
        public override void Enter()
        {
            base.Enter();
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_liYan._deathState);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (Time.time >= _liYan.timerBomb + _liYan.dropBombTimeRate)
                _stateMachine.ChangeState(_liYan._DropBombState);
            if (Time.time >= _startTime + _scaredTime)
            {
                _isScaredTimeElapsed = true;
                _entityData.timeOfFear = 0f;
                _stateMachine.ChangeState(_liYan._idleState);
            }
            _entity.Move(_entityData.movementSpeed);

        }

        #endregion
    }
}