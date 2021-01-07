using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hypodoche{
    public class Ice_DeathState : State
    {
         #region Variables
        private IceCrow _crow;



        public Ice_DeathState(Entity entity, FiniteStateMachine stateMachine, string animationName, IceCrow crow)
            : base(entity, stateMachine, animationName)
        {
            _crow = crow;
        }
        #endregion

        #region Methods



        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            _crow.GetHalja().setIceCrowDead(true);
            _crow.DestroyMinion();
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

        #endregion
    }
}
