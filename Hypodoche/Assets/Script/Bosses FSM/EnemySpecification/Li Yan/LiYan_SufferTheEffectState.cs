using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class LiYan_SufferTheEffectState : SufferTheEffectState
    {
        #region Variables
        private LiYan _liYan;

        public LiYan_SufferTheEffectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Effects effect, string type, LiYan liYan)
            : base(entity, stateMachine, animationName, entityData, effect, type)
        {
            _liYan = liYan;
        }
        #endregion

        #region Methods

        
        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
              if (_entityData.health <= 0)
                _stateMachine.ChangeState(_liYan._deathState);
            
            if (_entityData.timeOfFear == 0f)
            {
                _liYan._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_liYan._moveState);
            }
            else
            {
                _liYan._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_liYan._scareState); //todo boolean for direction
            }
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