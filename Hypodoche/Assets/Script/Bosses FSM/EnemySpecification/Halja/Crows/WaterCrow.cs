using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hypodoche{
    public class WaterCrow : Entity
    {

        #region variables
        private bool _isIneluttable;
        [SerializeField]private IceCrow  _iceCrow;
        [SerializeField] D_IdleState _idleData;
        public Water_idleState _IdleState {get; private set;}
        public Water_MoveState _MoveState {get; private set;}

        private Halja _halja;
    
        public float _timer;

        public float unbreakableBond;

        private Transform _playerPosition;


        #endregion

        #region methods


        public WaterCrow(Halja halja){
            _halja = halja;
        }

        public override void Start()
        {
            base.Start();
            _timer = Time.time;
            unbreakableBond = 20f;
            _MoveState = new Water_MoveState(this,_stateMachine,"run",_entityData,this);
            _IdleState = new Water_idleState(this,_stateMachine,"idle",_idleData,this);
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
        #endregion

        #region setter

        public void setVulnerability(bool vulnerable){
            _isIneluttable = vulnerable;
        }

         public void setIceCrow(IceCrow iceCrow){
            _iceCrow = iceCrow;
        }

        public void setPlayerPosition(Transform playerposition){
            _playerPosition = playerposition == null ? null : playerposition;
        }
     
        #endregion



    }
}

