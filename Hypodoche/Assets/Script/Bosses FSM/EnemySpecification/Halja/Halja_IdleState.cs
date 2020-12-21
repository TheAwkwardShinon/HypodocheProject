using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Halja_IdleState : IdleState
    {
        private Halja _halja;
        public Halja_IdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_IdleState idleData, Halja halja) : base(entity, stateMachine, animationName, idleData)
        {
            _halja = halja;
        }

        public override void Enter()
        {
            if (_entity._entityData.health <= 0)
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
            {
                _stateMachine.ChangeState(_halja._unbreakableBond);
            }
            else if (_isIdleTimeElapsed)
            {
                _stateMachine.ChangeState(_halja._moveState);
            }
        }
    }
}
