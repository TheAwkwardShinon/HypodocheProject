using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class B1_FireAttack : State
    {
        #region Variables
        protected Transform _playerPosition;
        protected B1_D_Fire _playerFireData;
        private Boss1 _boss1;
        #endregion

        #region Methods
        public B1_FireAttack(Entity entity, FiniteStateMachine stateMachine, string animationName, B1_D_Fire playerFireData, Boss1 boss)
            : base(entity, stateMachine, animationName)
        {
            //_playerPosition = playerPosition;
            _playerFireData = playerFireData;
            _boss1 = boss;
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
        }
        #endregion
    }
}