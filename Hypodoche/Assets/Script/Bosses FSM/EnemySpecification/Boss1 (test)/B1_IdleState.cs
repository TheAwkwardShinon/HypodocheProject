using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class B1_IdleState : IdleState
    {
        #region Variables
        private Boss1 _boss1;
        public B1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_IdleState idleData, Boss1 boss)
            : base(entity, stateMachine, animationName, idleData)
        {
            _boss1 = boss;
        }
        #endregion

        #region Methods
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

            if (_isIdleTimeElapsed)
                _stateMachine.ChangeState(_boss1._moveState);
        }

        #endregion
    }
}
