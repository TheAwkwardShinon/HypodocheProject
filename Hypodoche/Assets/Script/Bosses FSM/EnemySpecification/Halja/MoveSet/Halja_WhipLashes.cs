using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Halja_WhipLashes : State
    {
        #region variables
        private Halja _halja;
        private bool _hit;
        private Collider _player;

        #endregion

        #region methods
        public Halja_WhipLashes(Entity entity, FiniteStateMachine stateMachine, string animationName, Halja halja) : base(entity, stateMachine, animationName)
        {
            _halja = halja;
        }


        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
             Collider[] player = Physics.OverlapSphere(_halja.transform.position,_halja.getWhiplashesMaxDistance(),LayerMask.GetMask("Player"));
            _player = player.Length == 0 ? null : player[0];
            if(_player == null)
                _stateMachine.ChangeState(_halja._moveState);
            else{
                _player.GetComponent<PlayerStatus>().TakeDamage(5f);
                _halja.setWhipLashesClock(Time.time);
                _stateMachine.ChangeState(_halja._moveState);
            }
        }

        public override void Enter()
        {
            base.Enter();
            _hit = false;
            _animWaiter.StartCoroutine(_animWaiter.waitSomeSeconds(this,0.4f));
        }

  
        public override void Exit()
        {
            base.Exit();
            _halja.setWhipLashesClock(Time.time);
        }

        public override void Update()
        {
            base.Update();
        }
        #endregion
    }
}
