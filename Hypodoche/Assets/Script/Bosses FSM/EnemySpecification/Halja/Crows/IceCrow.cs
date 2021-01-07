using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class IceCrow : Entity
    {

        #region variables
        private bool _isIneluttable; //phase 2


        private WaterCrow _waterCrow;
    
        [SerializeField] D_IdleState _idleData;

        public Ice_UnbreakableBond _unbreakableBond {get; private set;}
        public Ice_idleState _IdleState {get; private set;}
        public Ice_MoveState _MoveState {get; private set;}

        private Transform _playerPosition;

        private Halja _halja;
        private  float _timer;

        [SerializeField] private float _unbreakableBondDuration;
        [SerializeField] private float _unbreakableBondCountDown; // ogni 20f fa unbreakablebond

        #endregion

        #region methods


        public override void Start()
        {
            base.Start();
            _timer = Time.time;
            _unbreakableBond = new Ice_UnbreakableBond(this, _stateMachine, "unbreakableBond",this);
            _MoveState = new Ice_MoveState(this,_stateMachine,"run",_entityData,this);
            _IdleState = new Ice_idleState(this,_stateMachine,"idle",_idleData,this);
            _stateMachine.InitializeState(_MoveState);

        }

        public override void Update()
        {
            base.Update();
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

        public WaterCrow GetWaterCrow(){
            return _waterCrow;
        }

        #endregion

        #region setter


        public void setVulnerability(bool vulnerable){
            _isIneluttable = vulnerable;
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
     

        
        #endregion



    }
}
