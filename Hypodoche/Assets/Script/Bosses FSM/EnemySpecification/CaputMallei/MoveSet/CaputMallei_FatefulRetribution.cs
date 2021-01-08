using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class CaputMallei_FatefulRetribution : State
    {
        private Caputmallei _caputMallei;

        private GameObject _projectile;

        public CaputMallei_FatefulRetribution(Entity entity, FiniteStateMachine stateMachine, string animationName, Caputmallei caputmallei) : base(entity, stateMachine, animationName)
        {
            _caputMallei = caputmallei;
        }


        public override void Enter()
        {
            base.Enter();
            _projectile = _caputMallei.getBloodyProjectile();
            _animWaiter.StartCoroutine(_animWaiter.waitSomeSeconds(this,0.4f));

        }


        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            _caputMallei.instantiateBloodyProjectile();
            _caputMallei.setFatefulRetributionClock(Time.time);
            _stateMachine.ChangeState(_caputMallei._moveState);
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
