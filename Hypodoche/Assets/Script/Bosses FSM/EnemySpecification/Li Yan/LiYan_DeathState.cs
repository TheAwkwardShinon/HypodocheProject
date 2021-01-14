using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Hypodoche
{
    public class LiYan_DeathState : State
    {
        #region Variables
        private LiYan _liYan;
        private bool _isDead = false;



        public LiYan_DeathState(Entity entity, FiniteStateMachine stateMachine, string animationName, LiYan liYan)
            : base(entity, stateMachine, animationName)
        {
            _liYan = liYan;
        }
        #endregion

        #region Methods

         public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            _liYan.DestroyBoss();
            Debug.Log("Li Yan è morta, avanziamo");
            if(!_isDead){
                _isDead = true;
                CampaignProgressionManager cpm = GameObject.FindObjectOfType<CampaignProgressionManager>();
                cpm.Advance(false);
            }
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



        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        #endregion
    }
}
