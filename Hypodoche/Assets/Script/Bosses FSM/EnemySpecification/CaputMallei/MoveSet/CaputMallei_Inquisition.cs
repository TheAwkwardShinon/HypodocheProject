using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class CaputMallei_Inquisition : State
    {
        private Caputmallei _caputmallei;

        private GameObject _player;

        public CaputMallei_Inquisition(Entity entity, FiniteStateMachine stateMachine, string animationName, Caputmallei caputMallei) : base(entity, stateMachine, animationName)
        {
            _caputmallei = caputMallei;
        }

        public override void Enter()
        {
            base.Enter();
            _animWaiter.StartCoroutine(_animWaiter.waitSomeSeconds(this,0.625f));

        }


        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();

            Collider[] player = Physics.OverlapSphere(_caputmallei.transform.position,_caputmallei.getInquisitionMaxDistance(),LayerMask.GetMask("Player"));
            _player = player.Length == 0 ? null : player[0].gameObject;
            if(_player == null){
                _caputmallei.SetInquisitionClock(Time.time);
                _caputmallei.setFatefulRetributionClock(Time.time);
                _stateMachine.ChangeState(_caputmallei._moveState);
            }
            else{
                _player.GetComponent<PlayerStatus>().TakeDamage(_caputmallei.getInquisitionDamage());
                _caputmallei.SetInquisitionClock(Time.time);
                _caputmallei.setFatefulRetributionClock(Time.time);
                _stateMachine.ChangeState(_caputmallei._moveState);
            }
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
