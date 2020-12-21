using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Halja_SufferTheEffectState : SufferTheEffectState
    {
        private Halja _halja;
        public Halja_SufferTheEffectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Effects effect, string type, Halja halja) : base(entity, stateMachine, animationName, entityData, effect, type)
        {
            _halja = halja;
        }

        public override void Enter()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_halja._deathState);
            base.Enter();

            if (_entityData.timeOfFear == 0f)
            {
                _halja._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_halja._moveState);
            }
            else
            {
                _halja._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_halja._scareState); //todo boolean for direction
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
    }
}
