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
            if(_halja.getWhiplashesCycles() <= 0){
                _halja.setWhipLashesClock(Time.time);
                _halja.setWhipLashesCountdown(6f);
                _halja.setChainOfDestinyCountdown(1.5f);
                _halja.setChainOfDestinyClock(Time.time);
                _halja.setPunishmentCountdown(4f);
                _halja.setPunishmentClock(Time.time);
                _halja.setWhipLashesCycles(3);
                _stateMachine.ChangeState(_halja._playerDetectState);
            }
            else{
                Collider[] player = Physics.OverlapSphere(_halja.transform.position,_halja.getWhiplashesMaxDistance(),LayerMask.GetMask("Player"));
                _player = player.Length == 0 ? null : player[0];
                if(_player == null){
                    _halja.setWhipLashesCycles(_halja.getWhiplashesCycles()-1);
                    _stateMachine.ChangeState(_halja._whipLashes);
                }
                else{
                    _player.GetComponent<PlayerStatus>().TakeDamage(2f);
                    _halja.setWhipLashesCycles(_halja.getWhiplashesCycles()-1);
                    _stateMachine.ChangeState(_halja._whipLashes);
                }
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
            if(_player != null){
                _entity.setDirection((_player.transform.position- _entity.transform.position).normalized);
                if(Vector3.Distance(_halja.transform.position,_player.transform.position) >= 5f)
                 _entity.Move(_entity._entityData.movementSpeed);
            }
            else{
                _entity.Move(_entity._entityData.movementSpeed);
            }

        }
        #endregion
    }
}
