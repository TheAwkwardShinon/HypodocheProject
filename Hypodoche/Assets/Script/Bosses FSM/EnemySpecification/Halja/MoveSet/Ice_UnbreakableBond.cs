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

        private float _distToHalja;
        private float _counter;

        private float _secondCounter;

        private float _begin;

        private LineRenderer _secondLr;

        private Vector3 _spitPosition;


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
            _spitPosition = _iceCrow.getThrowChainPosition().position;
            /*WaterCrow w = _waterCrow;
            Transform _waterSpit = _waterCrow.getThrowChainPosition();*/
            
            _counter = 0f;
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0,_spitPosition);
            _lineRenderer.startWidth = 0.3f;
            _lineRenderer.endWidth = 0.3f;
            try{
                _waterCrow = _iceCrow.GetWaterCrow();
                if(_waterCrow == null){
                    _stateMachine.ChangeState(_iceCrow._MoveState);
                }

                _dist = Vector3.Distance(_spitPosition, _waterCrow.getThrowChainPosition().position);
                _distToHalja = Vector3.Distance(_spitPosition, _iceCrow.GetHalja().getThrowChainPosition().position);
                if(!_iceCrow.IsIneluttable()){
                    _secondLr = _iceCrow.getThrowChainPosition().GetComponent<LineRenderer>();
                    _secondLr.enabled = true;
                    _secondLr.SetPosition(0,_spitPosition);
                    _secondLr.startWidth = 0.3f;
                    _secondLr.endWidth = 0.3f;
                }
            }catch(NullReferenceException e){
                Debug.Log("whatisnuulllll??? baby don't hurt me, no more: "+e);
                if(_waterCrow == null){
                    Debug.Log("yep, watercrow is null");
                }
                else Debug.Log("wtf");
            }

        }

        public override void Exit()
        {
            base.Exit();
            _iceCrow.setTimer(Time.time);
            _lineRenderer.enabled = false;
            try{
                if(!_iceCrow.IsIneluttable()){
                    _secondLr.enabled = false;
                }
            }catch(NullReferenceException e){
                Debug.Log("[UnbreakableBond]: "+e);

            }catch(MissingReferenceException m){
                Debug.Log("[UnbreakableBond]: "+m);
            }  
        }


        public override void Update()
        {
            base.Update();
            try{
                _iceCrow.setPlayerPosition(_iceCrow.isPlayerInAggroRange());

                if(!_iceCrow.IsIneluttable()){
                    if(_secondCounter <= _distToHalja){ //just a simple animation
                        _secondCounter += .1f / _lineDrawSpeed;
                        float x = Mathf.Lerp(0,_distToHalja,_secondCounter);
                        Vector3 pointA = _spitPosition;
                        Vector3 pointB = _iceCrow.GetHalja().getThrowChainPosition().position;
                        Vector3 pointAngleLine = x * Vector3.Normalize(pointB-pointA) + pointA;
                        _secondLr.SetPosition(1,pointAngleLine);
                    }
                }
                
                if(_counter <= _dist){ //just a simple animation
                    _counter += .1f / _lineDrawSpeed;
                    float x = Mathf.Lerp(0,_dist,_counter);
                    Vector3 pointA = _spitPosition;
                    Vector3 pointB = _waterCrow.getThrowChainPosition().position;
                    Vector3 pointAngleLine = x * Vector3.Normalize(pointB-pointA) + pointA;
                    _lineRenderer.SetPosition(1,pointAngleLine);

                }
                _lineRenderer.SetPosition(0,_spitPosition);
                _lineRenderer.SetPosition(1,_waterCrow.getThrowChainPosition().position);
                if(!_iceCrow.IsIneluttable()){
                    _secondLr.SetPosition(0,_spitPosition);
                    _secondLr.SetPosition(1,_iceCrow.GetHalja().getThrowChainPosition().position);
                }
                
                RaycastHit Hit;
            
                if(Physics.Raycast(_spitPosition,(_waterCrow.getThrowChainPosition().position-_spitPosition).normalized, out Hit,
                    Vector3.Distance(_spitPosition,_waterCrow.getThrowChainPosition().position),LayerMask.GetMask("Player"))){
                        StunData st = new StunData();
                        st.isEmpty = false;
                        st.time = 5f;
                        Hit.collider.gameObject.GetComponent<PlayerStatus>().AddStatus(new Effects(new SlowData(),st,new DamageOverTimeData(),
                            new DamageData(),new FearData(), false, new SlowOverAreaData(),new DamageOverAreaData(),new EnhanceData()));
                }

                if(!_iceCrow.IsIneluttable()){
                    if(Physics.Raycast(_spitPosition,(_iceCrow.GetHalja().getThrowChainPosition().position-_spitPosition).normalized, out Hit,
                    Vector3.Distance(_spitPosition,_iceCrow.GetHalja().getThrowChainPosition().position),LayerMask.GetMask("Player"))){
                        StunData st = new StunData();
                        st.isEmpty = false;
                        st.time = 5f;
                        Hit.collider.gameObject.GetComponent<PlayerStatus>().AddStatus(new Effects(new SlowData(),st,new DamageOverTimeData(),
                            new DamageData(),new FearData(), false, new SlowOverAreaData(),new DamageOverAreaData(),new EnhanceData()));
                    }
                }

                if(Time.time >=_begin + _iceCrow.getUnbreakableBondDuration()){
                    _stateMachine.ChangeState(_iceCrow._MoveState);  
                }
            }catch(NullReferenceException e){
                _stateMachine.ChangeState(_iceCrow._MoveState); 
            }catch( MissingReferenceException m){
                _stateMachine.ChangeState(_iceCrow._MoveState); 
            }                 
        }
    }
}
