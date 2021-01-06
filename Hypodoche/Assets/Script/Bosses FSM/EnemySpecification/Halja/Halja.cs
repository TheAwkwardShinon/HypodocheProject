using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Halja : Entity, Boss
    {
        #region Variables

        #region boss-state
        public Halja_IdleState _idleState { get; private set; }
        public Halja_MoveState _moveState { get; private set; }
        public Halja_SufferTheEffectState _sufferEffectState { get; private set; }
        public Halja_PlayerDetectState _playerDetectState { get; private set; }
        public Halja_ChaseState _chaseState { get; private set; }
        public Halja_ScaredState _scareState { get; private set; }
        public Halja_DeathState _deathState { get; private set; }

        public Halja_ChainOfDestiny _chainOfDestiny { get; private set; }
        public Halja_Punishment _punishment { get; private set; }

        public Halja_WhipLashes _whipLashes { get; private set; }

        #endregion


        #region move-set ranges
        [SerializeField] private float _chainOfDestinyMaxDistance;
        [SerializeField] private float _chainOfDestinyMinDistance;

        [SerializeField] private float _punishmentMaxDistance;
        [SerializeField] private float _punishmentMinDistance;

        [SerializeField] private float _whipLashestMaxDistance;

        [SerializeField] private float _whipLashesMinDistance;

        #endregion

        #region attack-moves-countdown
        [SerializeField] private float _punishmentCountdown;
        [SerializeField] private  float _chainOfDestinyCountdown;

        [SerializeField] private  float _whipLashesCountdown;

        #endregion



        #region clocks
        private  float _punishmentClock;
        private float _chainOfDestinyClock;
        private float _wiphLashesClock;

        #endregion



        #region scriptableObject

        [SerializeField] private D_IdleState _idleData;

        #endregion

        #region crows
        [SerializeField] protected IceCrow _iceCrow;
        [SerializeField] protected WaterCrow _waterCrow;

        #endregion


        
        #region drawline-variables
        public LineRenderer lr;

        [SerializeField] protected Transform _throwChainPosition;

        #endregion

        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();
            lr = GetComponent<LineRenderer>();
            _punishmentClock = Time.time;
            _chainOfDestinyClock = Time.time;
            _moveState = new Halja_MoveState(this, _stateMachine, "run", _entityData, this);
            _idleState = new Halja_IdleState(this, _stateMachine, "idle", _idleData, this);
            _scareState = new Halja_ScaredState(this, _stateMachine, "scared", _entityData, this);
            _deathState = new Halja_DeathState(this, _stateMachine, "death", this);
            _playerDetectState = new Halja_PlayerDetectState(this, _stateMachine, "playerDetect", _entityData, this);
            _punishment = new Halja_Punishment(this,_stateMachine,"punishment",this);
            _whipLashes = new Halja_WhipLashes(this,_stateMachine,"whiplashes",this);
            /*
            Instantiate(_iceCrow);
            Instantiate(_waterCrow);
            */
            _stateMachine.InitializeState(_idleState); //todo spawn state
        }

        public void OnDrawGizmos()
        {
            Vector3 leftLine = Quaternion.Euler(0,45,0) *  (transform.forward*-1f);
            Vector3 rightLine = Quaternion.Euler(0,-45,0) * (transform.forward*-1f);
            Debug.DrawRay(this.transform.position, leftLine, Color.red);
            Debug.DrawRay(this.transform.position, rightLine, Color.red);
            Debug.DrawRay(this.transform.position, transform.forward*-1f, Color.green);
            
            /*
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_throwChainPosition.position, _punishmentMaxDistance);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_throwChainPosition.position, _whipLashestMaxDistance);
            */
        }


        public void DestroyBoss()
        {
            Destroy(gameObject);
        }

        public  void exitFromTrap()
        {
                _entityData.slowOverArea = false;
                _entityData.damageOverArea = false;
                _entityData.enhanceMultiplier = 0f;
        }


        public void stepOnTrap(Effects effect)
        {
            _stateMachine.ChangeState(new Halja_SufferTheEffectState(this, _stateMachine, "sufferTheEffect", _entityData, effect, "trap", this));
        }

        #endregion

        #region getter  
        public float getHealth()
        {
            return _entityData.health;
        }

        #region crows-getter
        public WaterCrow GetWaterCrow(){
            return _waterCrow;
        }

         public IceCrow GetIceCrow(){
            return _iceCrow;
        }

        #endregion

        #region attack-moves-ranges-getters
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

        public float getWhiplashesMaxDistance(){
            return _whipLashestMaxDistance;
        }

        public float getWhipLashesMinDistance(){
            return _whipLashesMinDistance;
        }

        #endregion

        #region attacks-countdown-getters
        public float getPunishmentCountdown(){
            return _punishmentCountdown;
        }

        public float getChainOfDestinyCountdown(){
            return _chainOfDestinyCountdown;
        }


        public float getWhiplashesCountdown(){
            return _whipLashesCountdown;
        }
        #endregion


        public Transform getThrowChainPosition(){
            return _throwChainPosition;
        }

        #region clocks-getter
        public float getChainOfDestinyClock(){
            return _chainOfDestinyClock;
        }

        public float getPunishmentClock(){
            return _punishmentClock;
        }

        public float getWhipLashesClock(){
            return _wiphLashesClock;
        }
        #endregion

        #endregion

        #region setter

        public void setChainOfDestinyClock(float time){
            _chainOfDestinyClock = time;
        }

        public void setPunishmentClock(float time){
            _punishmentClock = time;
        }

        public void setWhipLashesClock(float time){
            _wiphLashesClock = time;
        }


        #endregion
 
    }
}
