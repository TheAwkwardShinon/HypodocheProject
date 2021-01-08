using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hypodoche{
    public class Water_DeathState : State
    {
         #region Variables
        private WaterCrow _crow;



        public Water_DeathState(Entity entity, FiniteStateMachine stateMachine, string animationName, WaterCrow crow)
            : base(entity, stateMachine, animationName)
        {
            _crow = crow;
        }
        #endregion

        #region Methods



        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            
        }
        public override void Enter()
        {
            base.Enter();
            _crow.GetHalja().setWaterCrowDead(true);
            _crow.DestroyMinion();
            //_animWaiter.StartCoroutine(_animWaiter.waitTillTheAnimationEnds(_entity._animator,this));
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
