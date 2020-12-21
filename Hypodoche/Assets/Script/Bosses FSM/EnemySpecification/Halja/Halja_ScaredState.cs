using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Halja_ScaredState : ScaredState
    {

        private Halja _halja;
        public Halja_ScaredState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Halja halja) : base(entity, stateMachine, animationName, entityData)
        {
            _halja = halja;
        }

        public override void Enter()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_halja._deathState);
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (Time.time >= _halja.timerUnbreakableBond + _halja.unbreakableBondCountdown)
                _stateMachine.ChangeState(_halja._unbreakableBond);
            if (Time.time >= _startTime + _scaredTime)
            {
                _isScaredTimeElapsed = true;
                _entityData.timeOfFear = 0f;
                _stateMachine.ChangeState(_halja._idleState);
            }
            _entity.Move(_entityData.movementSpeed);

        }
    }
}
