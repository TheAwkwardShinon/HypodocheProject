using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class UnbreakableBond : State
    {
        private WaterCrow _waterCrow;
        private IceCrow _iceCrow;

        private Halja _halja;
        public UnbreakableBond(Entity entity, FiniteStateMachine stateMachine, string animationName, WaterCrow waterCrow, IceCrow iceCrow, Halja halja) : base(entity, stateMachine, animationName)
        {
            _waterCrow = waterCrow;
            _iceCrow = iceCrow;
            _halja = halja;
        }

        public override void Enter()
        {
            if(_halja.getHealth() <= 0)
                _stateMachine.ChangeState(_halja._deathState);
            base.Enter();
            _waterCrow.UnbreakableBond();
            _iceCrow.UnbreakableBond();
            _halja.timerUnbreakableBond = Time.time;
            _stateMachine.ChangeState(_halja._moveState);
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
