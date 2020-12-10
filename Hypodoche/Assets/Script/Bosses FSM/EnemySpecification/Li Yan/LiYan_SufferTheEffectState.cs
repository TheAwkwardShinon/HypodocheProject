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
        public override void Enter()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_liYan._deathState);
            base.Enter();

            if (_entityData.timeOfFear == 0f)
            {
                Debug.Log("cambio stato : sufferEffect -> move " + Time.time);
                _liYan._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_liYan._moveState);
            }
            else
            {
                Debug.Log("cambio stato : sufferEffect -> scare " + Time.time);
                _liYan._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_liYan._scareState); //todo boolean for direction
            }
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