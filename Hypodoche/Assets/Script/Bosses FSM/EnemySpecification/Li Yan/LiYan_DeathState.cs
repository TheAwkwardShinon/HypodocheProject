using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;

namespace Hypodoche
{
    public class LiYan_DeathState : State
    {
        #region Variables
        private LiYan _liYan;



        public LiYan_DeathState(Entity entity, FiniteStateMachine stateMachine, string animationName, LiYan liYan)
            : base(entity, stateMachine, animationName)
        {
            _liYan = liYan;
        }
        #endregion

        #region Methods
        public override void Enter()
        {
            base.Enter();
            _liYan.DestroyBoss();
        }

        public override void Exit()
        {
            base.Exit();

        }




        public override void Update()
        {
            base.Update();
           
        }



        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        #endregion
    }
}
