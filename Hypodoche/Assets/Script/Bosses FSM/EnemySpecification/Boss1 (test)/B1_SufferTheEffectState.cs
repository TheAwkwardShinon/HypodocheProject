using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class B1_SufferTheEffectState : SufferTheEffectState
    {
        #region Variables
        private Boss1 _boss1;

        public B1_SufferTheEffectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Collider col,string type, Boss1 boss)
            : base(entity, stateMachine, animationName, entityData,col,type)
        {
            _boss1 = boss;
        }
        #endregion

        #region Methods
        public override void Enter()
        {
            base.Enter();
            if(_entityData.timeOfFear == 0f)
                _stateMachine.ChangeState(_boss1._moveState);
            else _stateMachine.ChangeState(_boss1._scareState);
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