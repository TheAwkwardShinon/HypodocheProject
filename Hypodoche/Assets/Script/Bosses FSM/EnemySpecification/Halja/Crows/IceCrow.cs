using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class IceCrow : Entity
    {

        #region variables
        private bool _isIneluttable;
        [SerializeField] private WaterCrow _waterCrow;
        [SerializeField] public  GameObject _chain;
    
        [SerializeField] D_IdleState _idleData;

        public Ice_UnbreakableBond _unbreakableBond {get; private set;}
        public Ice_idleState _IdleState {get; private set;}
        public Ice_MoveState _MoveState {get; private set;}

        private Transform _playerPosition;

        private Halja _halja;
        public  float _timer;

        public float unbreakableBondDuration;
        public float unbreakableBond; // ogni 20f fa unbreakablebond

        #endregion

        #region methods


        public IceCrow(Halja halja){
            _halja = halja;
        }

        public override void Start()
        {
            base.Start();
            _timer = Time.time;
            unbreakableBond = 15f;
            unbreakableBondDuration = 6f;
            _unbreakableBond = new Ice_UnbreakableBond(this, _stateMachine, "unbreakableBond",_waterCrow,this);
            _MoveState = new Ice_MoveState(this,_stateMachine,"run",_entityData,this);
            _IdleState = new Ice_idleState(this,_stateMachine,"idle",_idleData,this);
            Debug.Log("i am about to enter in movestate");
            _stateMachine.InitializeState(_MoveState);

        }

        public override void Update()
        {
            base.Update();
        }

        public void destroyChain(){
            Destroy(_chain);
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

        public void setWaterCrow(WaterCrow waterCrow){
            _waterCrow = waterCrow;
        }
        
        public void setPlayerPosition(Transform playerposition){
            _playerPosition = playerposition == null ? null : playerposition;
        }
     

        
        #endregion



    }
}
