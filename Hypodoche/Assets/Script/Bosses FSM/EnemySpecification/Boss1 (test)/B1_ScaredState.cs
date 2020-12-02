using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class B1_ScaredState : ScaredState
    {
        #region Variables
        private Boss1 _boss1;
        public B1_ScaredState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Boss1 boss)
            : base(entity, stateMachine, animationName, entityData)
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
            Debug.Log("i still scared: "+Time.time);
            base.Update();
            if (Time.time >= _startTime + _scaredTime)
            {
                _isScaredTimeElapsed = true;
                _entityData.timeOfFear = 0f;
                _stateMachine.ChangeState(_boss1._idleState);
            }
            _entity.Move(_entityData.movementSpeed);

        }

        #endregion
    }
}