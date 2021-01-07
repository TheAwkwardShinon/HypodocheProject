using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Water_ChainOfDestiny : State
    {
        private WaterCrow _crow;
        private D_Entity _entityData;

        private Vector3 _playerPosition;

        private Vector3 _grabPosition;

        private GameObject _player;

        private float _dist;

        private float _counter;

        private float _lineDrawSpeed;


        private bool _caught = false;

        private GameObject _projectile;





        public Water_ChainOfDestiny(Entity entity, FiniteStateMachine stateMachine, string animationName,D_Entity data, WaterCrow crow, Vector3 playerposition) : base(entity, stateMachine, animationName)
        {
            _crow = crow;
            _entityData = data;
            _playerPosition = playerposition;
            _lineDrawSpeed = 2f;
            _dist =  _crow.getChainOfDestinyMaxDistance();
        }



        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();

        }

        public override void Enter()
        {
            base.Enter();
            _crow.lr.enabled = true;
            _caught = false;
            _crow.lr.SetPosition(0,_crow.getThrowChainPosition().position); //TODO chainPosition
            _crow.lr.startWidth = 0.3f;
            _crow.lr.endWidth = 0.3f;

            Collider[] playerHit = Physics.OverlapSphere(_crow.transform.position,14f,LayerMask.GetMask("Player"));
            if(playerHit.Length > 0){
                _grabPosition = playerHit[0].GetComponent<PlayerStatus>().getGrabZone().position;
                _playerPosition = playerHit[0].transform.position;
                _player = playerHit[0].gameObject;
                _projectile = _crow.instantiateProjectileChain();
                _projectile.GetComponent<ChainProjectile>().setTarget(_grabPosition,_crow.transform.position);
            }
            else _stateMachine.ChangeState(_crow._playerDetect);
        }

        public override void Exit()
        {
            base.Exit();
            _crow.lr.SetPosition(1,_crow.getThrowChainPosition().position);
            _crow.lr.enabled = false;
            _crow.setChainOfDestinyCountdown(5f);
            _crow.setChainOfDestinyClock(Time.time);
            _caught = false;


        }

        public override void Update(){
            base.Update();

            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_crow._death);

            if(_projectile == null){
                    
                _stateMachine.ChangeState(_crow._punishment);
            }
            else{
                _crow.lr.SetPosition(1,_projectile.transform.position);
                if(Vector3.Distance(_player.transform.position,_crow.transform.position) 
                    <= _crow.getPunishmentMaxDistance()){
                    _stateMachine.ChangeState(_crow._punishment);
                }
            }
        }
    }
}

