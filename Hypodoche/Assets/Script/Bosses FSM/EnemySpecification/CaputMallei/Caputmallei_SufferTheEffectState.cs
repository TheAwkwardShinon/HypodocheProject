using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Caputmallei_SufferTheEffectState : SufferTheEffectState
    {
        private Caputmallei _caputmallei;
        public Caputmallei_SufferTheEffectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Effects effect, string type, Caputmallei caputmallei) : base(entity, stateMachine, animationName, entityData, effect, type)
        {
            _caputmallei = caputmallei;
        }


        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            if (_entityData.health <= 0){
                _stateMachine.ChangeState(_caputmallei._deathState);
            }
            if (_entityData.timeOfFear == 0f)
            {
                _caputmallei._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_caputmallei._moveState);
            }
            else
            {
                //_caputmallei._moveState.setFromSufferEffect(true);
                _stateMachine.ChangeState(_caputmallei._moveState); 
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
    }
}
