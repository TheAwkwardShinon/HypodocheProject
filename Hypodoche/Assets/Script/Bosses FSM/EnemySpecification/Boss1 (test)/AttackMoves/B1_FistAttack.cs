using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Hypodoche
{
    public class B1_FistAttack : State
    {
        #region Variables
        protected Transform _playerPosition;
        protected B1_D_Fist _playerFistData;
        private Boss1 _boss1;
        #endregion

        #region Methods
        public B1_FistAttack(Entity entity, FiniteStateMachine stateMachine, string animationName, B1_D_Fist playerFistData, Boss1 boss)
            : base(entity, stateMachine, animationName)
        {
            //_playerPosition = playerPosition;
            _playerFistData = playerFistData;
            _boss1 = boss;
        }


        public override void Enter()
        {
            //base.Enter(); //in sto caso, voglio controllare l'animazione : i.e. indirizzarla verso un punto specifico.

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
