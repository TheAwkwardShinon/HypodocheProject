using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Halja_ChainOfDestiny : State
    {
        private Halja _halja;
        private D_Entity _entityData;

        private Vector3 _playerPosition;

        private float _dist;

        private float _counter;

        private float _lineDrawSpeed;

        public Halja_ChainOfDestiny(Entity entity, FiniteStateMachine stateMachine, string animationName,D_Entity data, Halja halja, Vector3 playerposition) : base(entity, stateMachine, animationName)
        {
            _halja = halja;
            _entityData = data;
            _playerPosition = playerposition;
            _lineDrawSpeed = 3f;
            _dist =  _halja.getChainOfDestinyMaxDistance();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("CODDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");

            _halja.lr.enabled = true;
            _halja.lr.SetPosition(0,_halja.transform.position);
            _halja.lr.startWidth = 1f;
            _halja.lr.endWidth = 1f;
             //Transform temp = _halja.isPlayerInAggroRange();
            //_playerPosition = temp == null ?  _playerPosition : temp.position;
        }


      


        public override void Exit()
        {
            base.Exit();
            _halja.lr.enabled = false;
            _halja._chainOfDestinyClock = Time.time;


        }

        public override void Update()
        {
            base.Update();
            RaycastHit Hit;
            //Debug.DrawRay(_halja.transform.position,(_playerPosition - _halja.transform.position).normalized,Color.red);
            if(Physics.Raycast(_halja.transform.position,(_playerPosition - _halja.transform.position ).normalized, out Hit,
                    _dist,LayerMask.GetMask("Player"))){

                _dist =  Vector3.Distance(_halja.transform.position,Hit.point);
                if(_counter <= _dist){ //just a simple animation
                    _counter += .1f / _lineDrawSpeed;
                    float x = Mathf.Lerp(0,_dist,_counter);
                    Vector3 pointA = _halja.transform.position;
                    Vector3 pointB = Hit.point;
                    Vector3 pointAngleLine = x * Vector3.Normalize(pointB-pointA) + pointA;
                    _halja.lr.SetPosition(1,pointAngleLine);
                }
                //Hit.collider.gameObject.GetComponent<PlayerStatus>().TakeDamage(5f); //per ora poi dovremmo freezare i movimenti;
                Hit.collider.gameObject.transform.position = Vector3.MoveTowards(Hit.collider.gameObject.transform.position,_halja.transform.position,
                            10f * Time.deltaTime);
                if(Vector3.Distance(Hit.collider.gameObject.transform.position,_halja.transform.position) <=1f){
                    _stateMachine.ChangeState(_halja._punishment);
                }
            }
            else{
                if(_counter <= _dist){ //just a simple animation
                    _counter += .1f / _lineDrawSpeed;
                    float x = Mathf.Lerp(0,_dist,_counter);
                    Vector3 pointA = _halja.transform.position;
                    Vector3 pointB = _playerPosition;
                    Vector3 pointAngleLine = x * Vector3.Normalize(pointB-pointA) + pointA;
                    _halja.lr.SetPosition(1,pointAngleLine);
                }
                else{
                    _halja.lr.enabled = false;
                    _stateMachine.ChangeState(_halja._moveState);
                }
            }

        }
    }
}
