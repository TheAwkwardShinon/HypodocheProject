using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class LiYan_DropBombState : State
    {
        #region Variables
        private LiYan _liYan;



        public LiYan_DropBombState(Entity entity, FiniteStateMachine stateMachine, string animationName, LiYan liYan)
            : base(entity, stateMachine, animationName)
        {
            _liYan = liYan;
        }
        #endregion

        #region Methods
        public override void Enter()
        {
            base.Enter();
            if(_entity._entityData.health <= 0)
                _stateMachine.ChangeState(_liYan._deathState);
            //fa spawnare la bomba;
            _liYan.timerBomb = Time.time; //restart timer
            _stateMachine.ChangeState(_liYan._moveState);
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
