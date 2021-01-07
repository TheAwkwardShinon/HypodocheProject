using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Halja_ChainOfDestiny : State
    {
        private Halja _halja;
        private D_Entity _entityData;

        private Vector3 _playerPosition;

        private Vector3 _grabPosition;

        private GameObject _player;

        private float _dist;

        private float _counter;

        private float _lineDrawSpeed;


        private bool _caught = false;

        private GameObject _projectile;





        public Halja_ChainOfDestiny(Entity entity, FiniteStateMachine stateMachine, string animationName,D_Entity data, Halja halja, Vector3 playerposition) : base(entity, stateMachine, animationName)
        {
            _halja = halja;
            _entityData = data;
            _playerPosition = playerposition;
            _lineDrawSpeed = 2f;
            _dist =  _halja.getChainOfDestinyMaxDistance();
        }



        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();

        }


       

        public override void Enter()
        {
            base.Enter();
            _halja.lr.enabled = true;
            _caught = false;
            _halja.lr.SetPosition(0,_halja.getThrowChainPosition().position); //TODO chainPosition
            _halja.lr.startWidth = 0.3f;
            _halja.lr.endWidth = 0.3f;

            Collider[] playerHit = Physics.OverlapSphere(_halja.transform.position,14f,LayerMask.GetMask("Player"));
            if(playerHit.Length > 0){
                _grabPosition = playerHit[0].GetComponent<PlayerStatus>().getGrabZone().position;
                _playerPosition = playerHit[0].transform.position;
                _player = playerHit[0].gameObject;
                _projectile = _halja.instantiateProjectileChain();
                _projectile.GetComponent<ChainProjectile>().setTarget(_grabPosition);
            }
            else _stateMachine.ChangeState(_halja._playerDetectState);
        }


      


        public override void Exit()
        {
            base.Exit();
            _halja.lr.SetPosition(1,_halja.getThrowChainPosition().position);
            _halja.lr.enabled = false;
            _halja.setChainOfDestinyCountdown(5f);
            _halja.setChainOfDestinyClock(Time.time);
            _caught = false;


        }
/*
        public bool chainAnimation(Vector3 hitPoint){
            if(_counter <= _dist){ //just a simple animation
                _counter += .1f * _lineDrawSpeed;
                float x = Mathf.Lerp(0,_dist,_counter);
                Vector3 pointA = _halja.getThrowChainPosition().position;
                Vector3 pointB = hitPoint;//_halja.lr.GetPosition(1); //hitPoint;
                Vector3 pointAngleLine = x * Vector3.Normalize(pointB-pointA) + pointA;
                _halja.lr.SetPosition(1,pointAngleLine);
                return false; // animation not end
            }
            else {
                return true;
            }
        }*/


        public override void Update(){
            base.Update();

            if(_projectile == null){
                    
                _stateMachine.ChangeState(_halja._whipLashes);
            }
            else{
                _halja.lr.SetPosition(1,_projectile.transform.position);
                if(Vector3.Distance(_player.transform.position,_halja.transform.position) 
                    <= _halja.getPunishmentMaxDistance()){
                    _stateMachine.ChangeState(_halja._punishment);
                }
            }
        }
/*
        public  void Updatesa()
        {
            //base.Update();
                RaycastHit Hit;
                if(_caught){
                    _player.GetComponent<PlayerStatus>().setStun(3f,true);
                    _player.transform.position = Vector3.MoveTowards(_player.transform.position,_halja.transform.position,
                                10f * Time.deltaTime);
                     _halja.lr.SetPosition(1,_player.GetComponent<PlayerStatus>().getGrabZone().position);
                     if(Vector3.Distance(_player.transform.position,_halja.transform.position) <= _halja.getPunishmentMaxDistance()){
                                Debug.Log("[player is now on punishment aggro] : "+Time.time);
                                _stateMachine.ChangeState(_halja._punishment);
                    }
                    return;
                }
    
                if(Physics.Raycast(_halja.getThrowChainPosition().position,(_grabPosition - _halja.getThrowChainPosition().position ).normalized, out Hit,
                        _dist,LayerMask.GetMask("Player"))){
                    Debug.Log("[palyer hit by first raycast] : "+Time.time);

                    //Vector3 hitPoint = Hit.point;
                    _player = Hit.collider.gameObject;
                    _dist = Vector3.Distance(_player.GetComponent<PlayerStatus>().getGrabZone().position,_halja.getThrowChainPosition().position);
                    Debug.Log("distance is : "+_dist);

                    if(chainAnimation(_player.GetComponent<PlayerStatus>().getGrabZone().position)){
                        _halja.lr.SetPosition(1,_player.GetComponent<PlayerStatus>().getGrabZone().position);
                        
                        _caught = true;
                        return;
                    }
                }
                else{
                    Debug.Log("[not hit the player ] : chain animation "+Time.time);
                    _dist = _halja.getChainOfDestinyMaxDistance();
                    if(chainAnimation(_grabPosition)){
                         Debug.Log("[not hit the player] : reached max distance, about to change state "+Time.time);
                        _halja.lr.enabled = false;
                        _stateMachine.ChangeState(_halja._moveState);
                    }
                }
            

        }*/
    }
}
