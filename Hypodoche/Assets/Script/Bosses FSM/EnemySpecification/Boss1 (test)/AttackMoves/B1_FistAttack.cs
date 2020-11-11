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


        public bool isHittable()
        {
            return _boss1.hittable(_playerFistData.angleRange, _playerFistData.radius, _playerFistData.fromRange,
                           _playerFistData.toRange, _boss1._entityData.whatIsPlayer);
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("FISTTTT");
            //TODO vfx + danno.
            Exit();

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
