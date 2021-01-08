using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class IceWhipLashes : State
    {
        #region variables
        private IceCrow _crow;
        private bool _hit;
        private Collider _player;

        #endregion

        #region methods
        public IceWhipLashes(Entity entity, FiniteStateMachine stateMachine, string animationName, IceCrow crow) : base(entity, stateMachine, animationName)
        {
            _crow = crow;
        }


        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();

            Collider[] player = Physics.OverlapSphere(_crow.transform.position,_crow.getWhiplashesMaxDistance(),LayerMask.GetMask("Player"));
            _player = player.Length == 0 ? null : player[0];
            if(_player == null){
                _stateMachine.ChangeState(_crow._MoveState);
            }
            else{
                _player.GetComponent<PlayerStatus>().TakeDamage(2f);
                _stateMachine.ChangeState(_crow._MoveState);
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
            _crow.setWhipLashesClock(Time.time);
        }

        public override void Update()
        {
            base.Update();
            if(_player != null){
                _entity.setDirection((_player.transform.position- _entity.transform.position).normalized);
                if(Vector3.Distance(_crow.transform.position,_player.transform.position) >= 4f)
                 _entity.Move(_entity._entityData.movementSpeed);
            }
            else{
                _entity.Move(_entity._entityData.movementSpeed);
            }

        }
        #endregion
    }
}