using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche {
    public class Ice_UnbreakableBond : State
    {
        private IceCrow _iceCrow;
        private WaterCrow _waterCrow;
        private ChainSpawner _spawner;

        private LineRenderer _lineRenderer;
        private float _dist;

        private float _counter;

        private float _begin;

        private float _lineDrawSpeed;
        public Ice_UnbreakableBond(Entity entity, FiniteStateMachine stateMachine, string animationName, IceCrow iceCrow) : base(entity, stateMachine, animationName)
        {
            _iceCrow = iceCrow;
            _lineRenderer = _iceCrow.gameObject.GetComponent<LineRenderer>();
            _lineDrawSpeed = 6f;
            //_spawner = new ChainSpawner();
        }

        public override void Enter()
        {
            base.Enter();
            _begin = Time.time;
            
            _counter = 0f;
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0,_iceCrow.transform.position);
            _lineRenderer.startWidth = 1f;
            _lineRenderer.endWidth = 1f;
            _waterCrow = _iceCrow.GetWaterCrow();
            if(_waterCrow == null){
                _stateMachine.ChangeState(_iceCrow._MoveState);
            }
            _dist = Vector3.Distance(_iceCrow.transform.position, _waterCrow.transform.position);

        }

        public override void Exit()
        {
            base.Exit();
            _iceCrow.setTimer(Time.time);
            _lineRenderer.enabled = false;
        }


        public override void Update()
        {
            base.Update();
            try{
                _iceCrow.setPlayerPosition(_iceCrow.isPlayerInAggroRange());
                
                if(_counter <= _dist){ //just a simple animation
                    _counter += .1f / _lineDrawSpeed;
                    float x = Mathf.Lerp(0,_dist,_counter);
                    Vector3 pointA = _iceCrow.transform.position;
                    Vector3 pointB = _waterCrow.transform.position;
                    Vector3 pointAngleLine = x * Vector3.Normalize(pointB-pointA) + pointA;
                    _lineRenderer.SetPosition(1,pointAngleLine);

                }
                _lineRenderer.SetPosition(0,_iceCrow.transform.position);
                _lineRenderer.SetPosition(1,_waterCrow.transform.position);
                
                RaycastHit Hit;
            //Debug.DrawRay(_iceCrow.transform.position,(_waterCrow.transform.position-_iceCrow.transform.position).normalized,Color.red,1f);
            
                if(Physics.Raycast(_iceCrow.transform.position,(_waterCrow.transform.position-_iceCrow.transform.position).normalized, out Hit,
                    Vector3.Distance(_iceCrow.transform.position,_waterCrow.transform.position),LayerMask.GetMask("Player"))){
                        StunData st = new StunData();
                        st.isEmpty = false;
                        st.time = 5f;
                        Hit.collider.gameObject.GetComponent<PlayerStatus>().AddStatus(new Effects(new SlowData(),st,new DamageOverTimeData(),
                            new DamageData(),new FearData(), false, new SlowOverAreaData(),new DamageOverAreaData(),new EnhanceData()));
                }
                //_iceCrow.Move(_iceCrow._entityData.movementSpeed);

                if(Time.time >=_begin + _iceCrow.getUnbreakableBondDuration()){
                    _stateMachine.ChangeState(_iceCrow._MoveState);  
                }
            }catch(NullReferenceException e){
                _stateMachine.ChangeState(_iceCrow._MoveState); 
            }                    
        }
    }
}
