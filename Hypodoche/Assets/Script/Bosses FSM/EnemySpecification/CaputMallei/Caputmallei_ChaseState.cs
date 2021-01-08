using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Caputmallei_ChaseState : State
    {
        private Caputmallei _caputmallei;
        private D_Entity _entityData;

        private Vector3 _playerPosition;
        public Caputmallei_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Caputmallei caputmallei, Vector3 playerPosition) : base(entity, stateMachine, animationName)
        {
            _caputmallei = caputmallei;
            _entityData = entityData;
            _playerPosition = playerPosition;
        }

        public override void Enter()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_caputmallei._deathState);
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
    
            if (_caputmallei.isPlayerInAggroRange() == null)
            {
                _caputmallei.transform.position = Vector3.MoveTowards(_caputmallei.transform.position, _playerPosition, _speedWhenDetect * Time.fixedDeltaTime);
            }
            else{
                 _stateMachine.ChangeState(_caputmallei._playerDetect);
            }

        }
    }
}
