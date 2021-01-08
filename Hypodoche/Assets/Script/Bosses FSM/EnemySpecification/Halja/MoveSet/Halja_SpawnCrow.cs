using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Halja_SpawnCrow : State
    {

        private Halja _halja;
        public Halja_SpawnCrow(Entity entity, FiniteStateMachine stateMachine, string animationName, Halja halja) : base(entity, stateMachine, animationName)
        {
            _halja = halja;
        }

        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            _halja.crowSpawn();
            _halja.setSpawnCrowClock(Time.time);
            _stateMachine.ChangeState(_halja._moveState);
        }

        public override void Enter()
        {
            base.Enter();
            _animWaiter.StartCoroutine(_animWaiter.waitTillTheAnimationEnds(_entity._animator,this));
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
