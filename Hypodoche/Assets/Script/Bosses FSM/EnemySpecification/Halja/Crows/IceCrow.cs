using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class IceCrow : Entity,Minion
    {

        #region variables
        private bool _isIneluttable = true; //phase 2


        private WaterCrow _waterCrow;
    
        [SerializeField] D_IdleState _idleData;

        public Ice_UnbreakableBond _unbreakableBond {get; private set;}
        public Ice_idleState _IdleState {get; private set;}
        public Ice_MoveState _MoveState {get; private set;}

        public Ice_DeathState _death {get; private set;}

        public IceWhipLashes _whiplashes {get; private set;}

        public Ice_PlayerDetectState _PlayerDetect {get; private set;}

        private Transform _playerPosition;

        private Halja _halja;
        private  float _timer;

        [SerializeField] private float _unbreakableBondDuration;
        [SerializeField] private float _unbreakableBondCountDown; // ogni 20f fa unbreakablebond

        [SerializeField] private float _whipLashestMaxDistance;

        [SerializeField] private float _whipLashesMinDistance;
        [SerializeField] private  float _whipLashesCountdown;

        private float _whipLashesClock;

        [SerializeField] protected Transform _throwChainPosition;

        [SerializeField] private GameObject _crowHealthCanvas;

        private Enemy _enemy;



        #endregion

        #region methods


        public override void Start()
        {
            base.Start();
            _entityData.health = 300f;
            _enemy = gameObject.GetComponent<Enemy>();
            _timer = Time.time;
            _whipLashesClock = Time.time;
            _unbreakableBond = new Ice_UnbreakableBond(this, _stateMachine, "unbreakableBond",this);
            _MoveState = new Ice_MoveState(this,_stateMachine,"run",_entityData,this);
            _IdleState = new Ice_idleState(this,_stateMachine,"idle",_idleData,this);
            _death = new Ice_DeathState(this,_stateMachine,"death",this);
            _PlayerDetect = new Ice_PlayerDetectState(this,_stateMachine,"playerDetect",_entityData,this);
            _whiplashes = new IceWhipLashes(this,_stateMachine,"whiplashes",this);



            _stateMachine.InitializeState(_MoveState);

        }

        public override void Update()
        {
            base.Update();
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_death);
        }



        #endregion

        #region getter
        public bool IsIneluttable(){
            return _isIneluttable;
        }

        public Transform getPlayerPosition(){
            return _playerPosition == null ? null : _playerPosition;
        }

        public float getUnbreakableBondDuration(){
            return _unbreakableBondDuration;
        }

        public float getUnBreakableBondCountDown(){
            return _unbreakableBondCountDown;
        }

        public float getTimer(){
            return _timer;
        }

         public float getWhiplashesMaxDistance(){
            return _whipLashestMaxDistance;
        }

        public float getWhipLashesMinDistance(){
            return _whipLashesMinDistance;
        }

          public float getWhiplashesCountdown(){
            return _whipLashesCountdown;
        }

        public Transform getThrowChainPosition(){
            return _throwChainPosition;
        }

        public float getWhipLashesClock(){
            return _whipLashesClock;
        }


        public WaterCrow GetWaterCrow(){
            try{
                return _waterCrow;
            }catch(NullReferenceException e){
                Debug.Log("[getWaterCrow()]: "+e);
                return null;
            }
        }

        public Halja GetHalja(){
            return _halja;
        }

        #endregion

        #region setter


        public void setVulnerability(bool vulnerable){
            _isIneluttable = vulnerable;
            _enemy = GetComponent<Enemy>();
            _enemy.enabled = true;
            _crowHealthCanvas.SetActive(true);
        }

        public void setWaterCrow(WaterCrow waterCrow){
            _waterCrow = waterCrow;
        }
        
        public void setPlayerPosition(Transform playerposition){
            _playerPosition = playerposition == null ? null : playerposition;
        }

        public void setTimer(float timer){
            _timer = timer;
        }

        public void setHalja(Halja halja){
            _halja = halja;
        }
        public void setWhipLashesCountdown(float time){
            _whipLashesCountdown = time;
        }

        public void setWhipLashesClock(float time){
            _whipLashesClock = time;
        }

        public void setCanvas(GameObject canvas){
            _crowHealthCanvas = canvas;
        }

        public void DestroyMinion()
        {
            Destroy(gameObject);
        }

        public float getHealth()
        {
            return _entityData.health;
        }

          public void setHealth(float value)
        {
            _entityData.health -= value;
        }




        #endregion



    }
}
