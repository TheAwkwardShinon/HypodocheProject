using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Halja_ChaseState : State
    {
        private Halja _halja;
        private D_Entity _entityData;

        private Vector3 _playerPosition;
        public Halja_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Halja halja, Vector3 playerPosition) : base(entity, stateMachine, animationName)
        {
            _halja = halja;
            _entityData = entityData;
            _playerPosition = playerPosition;
        }

        public override void Enter()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_halja._deathState);
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (_entityData.isStun)
                return;
            float _speedWhenDetect = _entityData.isSlowed ? _entityData.speedWhenSlowed : _entityData.speedWhenDetect;
            if (_entityData.slowOverArea)
                _speedWhenDetect = _entityData.speedWhenSlowedArea;
                
            //float dstToTarget = Vector3.Distance(_halja.transform.position, _playerPosition);
    
            Transform tempPlayrPosition = _halja.GetIceCrow().getPlayerPosition() == null ? 
                _halja.GetWaterCrow().getPlayerPosition() : _halja.GetIceCrow().getPlayerPosition();
            
            if(tempPlayrPosition != null)
                _playerPosition = tempPlayrPosition.position;

            if (_halja.isPlayerInAggroRange() == null)
            {
                _halja.transform.position = Vector3.MoveTowards(_halja.transform.position, _playerPosition, _speedWhenDetect * Time.fixedDeltaTime);
                //_boss.transform.position += _playerPosition * _speedWhenDetect * Time.fixedDeltaTime;
            }
            else{
                 _stateMachine.ChangeState(_halja._playerDetectState);
            }

        }
    }
}
