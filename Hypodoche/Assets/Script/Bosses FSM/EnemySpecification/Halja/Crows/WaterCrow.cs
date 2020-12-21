using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hypodoche{
    public class WaterCrow : Entity, Crows
    {

        #region variables
        private bool _isIneluttable;
        [SerializeField]private IceCrow  _iceCrow;
        [SerializeField] D_IdleState _idleData;
        public Water_UnbreakableBond _unbreakableBond {get; private set;}
        public Crows_idleState _IdleState {get; private set;}
        public Crows_MoveState _MoveState {get; private set;}

    
        private float _timer;

        #endregion

        #region methods




        public override void Start()
        {
            base.Start();
            _unbreakableBond = new Water_UnbreakableBond(this, _stateMachine, "unbreakableBond",this,_iceCrow);
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
        #endregion

        #region setter
        public void newIceCrow(IceCrow iceCrow){
            _iceCrow = iceCrow;
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

