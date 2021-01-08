using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class CaputMallei_SundayMorning : State
    {
        private Caputmallei _caputMallei;

        private float _snapShotOfBossHealth;


        public CaputMallei_SundayMorning(Entity entity, FiniteStateMachine stateMachine, string animationName, Caputmallei caputmMallei) : base(entity, stateMachine, animationName)
        {
            _caputMallei = caputmMallei;
        }

        public override void Enter()
        {
            base.Enter();
            _snapShotOfBossHealth = _caputMallei.getHealth();
        }

        public override void ExecuteAfterAnimation() //aniamtion should be loop
        {
            base.ExecuteAfterAnimation();
        }

        public override void Exit()
        {
            base.Exit();
            _caputMallei.setSundayMorningClock(Time.time);
        }

        public override void Update()
        {
            base.Update();

            if(Time.time >= _startTime + _caputMallei.getSundayMorningChargeTime()  && _caputMallei.getHealth() >= _snapShotOfBossHealth)
                _stateMachine.ChangeState(_caputMallei._sundayMorningExplosion);
            else if(_caputMallei.getHealth() < _snapShotOfBossHealth){
                _stateMachine.ChangeState(_caputMallei._moveState);
            }


        }
    }
}
