using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hypodoche{
    public class Halja_DeathState : State
    {
         #region Variables
        private Halja _halja;
        private bool _isDead = false;


        public Halja_DeathState(Entity entity, FiniteStateMachine stateMachine, string animationName, Halja halja)
            : base(entity, stateMachine, animationName)
        {
            _halja = halja;
        }
        #endregion

        #region Methods



        public override void ExecuteAfterAnimation()
        {
            Debug.Log("Halja è morta, avanziamo");
            base.ExecuteAfterAnimation();
            if(!_isDead){
                _isDead = true;
                CampaignProgressionManager cpm = GameObject.FindObjectOfType<CampaignProgressionManager>();
                cpm.Advance(false);
            }
            _halja.DestroyBoss();
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
