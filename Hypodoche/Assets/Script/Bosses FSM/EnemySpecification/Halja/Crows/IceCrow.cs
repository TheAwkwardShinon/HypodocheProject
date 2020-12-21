using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class IceCrow : Entity, Crows
    {

        #region variables
        private bool _isIneluttable;
        [SerializeField]private WaterCrow _waterCrow;
        [SerializeField] public  GameObject _chain;
        [SerializeField] private float _chainOfDestinyDuratiuon;
        [SerializeField] D_IdleState _idleData;

        public Ice_UnbreakableBond _unbreakableBond {get; private set;}
        public Crows_idleState _IdleState {get; private set;}
        public Crows_MoveState _MoveState {get; private set;}


    
        private float _timer;

        #endregion

        #region methods



        public override void Start()
        {
            base.Start();
            _unbreakableBond = new Ice_UnbreakableBond(this, _stateMachine, "unbreakableBond",_waterCrow,this);
            _MoveState = new Crows_MoveState(this,_stateMachine,"run",_entityData,this);
            _IdleState = new Crows_idleState(this,_stateMachine,"idle",_idleData,this);
            _timer = Time.time;
            _stateMachine.setState(_MoveState);

        }

        public void UnbreakableBond(){
            _stateMachine.ChangeState(_unbreakableBond);
        }

        #endregion

        #region getter
        public bool IsIneluttable(){
            return _isIneluttable;
        }


         public float getChainOfDestinyDuration(){
            return _chainOfDestinyDuratiuon;
        }
        #endregion

        #region setter
        public void newWaterCrow(WaterCrow waterCrow){
            _waterCrow = waterCrow;
        }

        public void setVulnerability(bool vulnerable){
            _isIneluttable = vulnerable;
        }

        public Crows_idleState GetIdleState()
        {
            return _IdleState;
        }

        public Crows_MoveState GetMoveState()
        {
            return _MoveState;
        }

        public void Movecrow()
        {
            Move(_entityData.movementSpeed);
        }
        #endregion



    }
}
