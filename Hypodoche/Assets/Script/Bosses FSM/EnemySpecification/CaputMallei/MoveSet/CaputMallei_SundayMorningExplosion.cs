using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class CaputMallei_SundayMorningExplosion : State
    {

        private Caputmallei _caputMallei;

        private GameObject _player;

        public CaputMallei_SundayMorningExplosion(Entity entity, FiniteStateMachine stateMachine, string animationName, Caputmallei caputmallei) : base(entity, stateMachine, animationName)
        {
            _caputMallei = caputmallei;
        }

        public override void Enter()
        {
            base.Enter();
            _animWaiter.StartCoroutine(_animWaiter.waitSomeSeconds(this,0.6f));

        }

        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            _player = players[0]; //tanto lo trova sicuramente
            _player.gameObject.GetComponent<PlayerStatus>().TakeDamage(_caputMallei.getSundayMorningDamage());
            _caputMallei.setSundayMorningClock(Time.time);
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
