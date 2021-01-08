using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hypodoche{
    public class WaterCrow : Entity,Minion
    {

        #region variables
        private bool _isIneluttable = true;
        private IceCrow  _iceCrow;
        [SerializeField] D_IdleState _idleData;
        public Water_idleState _IdleState {get; private set;}
        public Water_MoveState _MoveState {get; private set;}

        public Water_PlayerDetectState _playerDetect {get; private set;}

        public Water_ChainOfDestiny _chainOfDestiny {get; private set;}

        public WaterPunishment _punishment {get; private set;}

        public Water_DeathState _death {get; private set;}


        private Halja _halja;

        
        [SerializeField] private float _punishmentMaxDistance;
        [SerializeField] private float _punishmentMinDistance;
        [SerializeField] private float _punishmentCountdown;

        [SerializeField] private float _chainOfDestinyMaxDistance;
        [SerializeField] private float _chainOfDestinyMinDistance;
        [SerializeField] private  float _chainOfDestinyCountdown;

        private Enemy _enemy;
    
        private  float _punishmentClock;
        private float _chainOfDestinyClock;


        private Transform _playerPosition;


        
        public LineRenderer lr;

        [SerializeField] protected Transform _throwChainPosition;

        [SerializeField] protected GameObject  _chainprojectile;


        [SerializeField] private GameObject _crowHealthCanvas;

        private GameObject iceCrowGO;


        #endregion

        #region methods


        public override void Start()
        {
            base.Start();
            _entityData.health = 300f;
            _punishmentClock = Time.time;
            _chainOfDestinyClock = Time.time;
            _enemy = gameObject.GetComponent<Enemy>();
            lr = GetComponent<LineRenderer>();
            _MoveState = new Water_MoveState(this,_stateMachine,"run",_entityData,this);
            _IdleState = new Water_idleState(this,_stateMachine,"idle",_idleData,this);
            _playerDetect = new Water_PlayerDetectState(this,_stateMachine,"playerDetect",_entityData,this);
            _punishment = new WaterPunishment(this,_stateMachine,"punishment",this);
            _death = new Water_DeathState(this,_stateMachine,"death",this);
            //_chainOfDestiny = new Water_ChainOfDestiny(this,_stateMachine,"idle",_idleData,this);



            _stateMachine.InitializeState(_MoveState);

        }


        public override void Update()
        {
            base.Update();
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_death);
        }

        public GameObject instantiateProjectileChain(){
            GameObject go= Instantiate(_chainprojectile,_throwChainPosition.position,Quaternion.identity);
            return go;
        }



        #endregion

        #region getter
        public bool IsIneluttable(){
            return _isIneluttable;
        }

        public Transform getPlayerPosition(){
            return _playerPosition == null ? null : _playerPosition;
        }

        public float getChainOfDestinyMaxDistance(){
            return _chainOfDestinyMaxDistance;
        }

         public float getChainOfDestinyMinDistance(){
            return _chainOfDestinyMinDistance;
        }

         public float getPunishmentMaxDistance(){
            return _punishmentMaxDistance;
        }

         public float getPunishmentMinDistance(){
            return _punishmentMinDistance;
        }

        public float getPunishmentCountdown(){
            return _punishmentCountdown;
        }

        public float getChainOfDestinyCountdown(){
            return _chainOfDestinyCountdown;
        }

        public Transform getThrowChainPosition(){
            return _throwChainPosition;
        }

        public float getChainOfDestinyClock(){
            return _chainOfDestinyClock;
        }

        public float getPunishmentClock(){
            return _punishmentClock;
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

         public void setIceCrow(IceCrow iceCrow){
            _iceCrow = iceCrow;
        }

        public void setPlayerPosition(Transform playerposition){
            _playerPosition = playerposition == null ? null : playerposition;
        }
     

        public void setHalja(Halja halja){
            _halja = halja;
        }


        public void setChainOfDestinyClock(float time){
            _chainOfDestinyClock = time;
        }

        public void setPunishmentClock(float time){
            _punishmentClock = time;
        }


        public void setPunishmentCountdown(float time){
            _punishmentCountdown = time;
        }

        public void setChainOfDestinyCountdown(float time){
            _chainOfDestinyCountdown = time;
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

/*
        public void setIceCrowGO(GameObject iceCrow){
            iceCrowGO = iceCrow;
            _iceCrow = iceCrow.GetComponent<IceCrow>();
        }
*/


        #endregion



    }
}

