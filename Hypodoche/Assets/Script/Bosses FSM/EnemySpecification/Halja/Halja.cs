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
        public Halja_SpawnCrow _spawnCrow { get; private set; }

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

         [SerializeField] private  float _crowSpawnCountdown;



        private int _whipLashesCycles;

        #endregion



        #region clocks
        private  float _punishmentClock;
        private float _chainOfDestinyClock;
        private float _wiphLashesClock;

        private float _crowSpawnClock;

        #endregion



        #region scriptableObject

        [SerializeField] private D_IdleState _idleData;

        #endregion

        #region crows
        protected IceCrow _iceCrow;
        protected WaterCrow _waterCrow;

        [SerializeField]protected GameObject _IceCrowGO;
        [SerializeField]protected GameObject _WaterCrowGO;



        private bool iceCrowDead = false;
        private bool waterCrowDead = false;


        private bool _secondPhase = false;
    

        #endregion


        
        #region drawline-variables
        public LineRenderer lr;

        [SerializeField] protected Transform _throwChainPosition;

        [SerializeField] protected GameObject  _chainprojectile;

        private GameObject _waterClone;
        private GameObject _iceClone;



        #endregion

        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();
            lr = GetComponent<LineRenderer>();
            _entityData.health = 1000f;
            _iceCrow = _IceCrowGO.GetComponent<IceCrow>();
            _waterCrow = _WaterCrowGO.GetComponent<WaterCrow>();
            _punishmentClock = Time.time;
            _chainOfDestinyClock = Time.time;
            _iceCrow = Instantiate(_iceCrow,new Vector3(0f,1f,0f),Quaternion.identity);
            _waterCrow = Instantiate(_waterCrow,new Vector3(0f,1f,0f),Quaternion.identity);
            _iceCrow.setWaterCrow(_waterCrow);
            _waterCrow.setIceCrow(_iceCrow);
            //_waterCrow.setVulnerability(false);
            //_iceCrow.setVulnerability(false);
            _iceCrow.setHalja(this);
            _waterCrow.setHalja(this);
            _moveState = new Halja_MoveState(this, _stateMachine, "run", _entityData, this);
            _idleState = new Halja_IdleState(this, _stateMachine, "idle", _idleData, this);
            _scareState = new Halja_ScaredState(this, _stateMachine, "scared", _entityData, this);
            _deathState = new Halja_DeathState(this, _stateMachine, "death", this);
            _playerDetectState = new Halja_PlayerDetectState(this, _stateMachine, "playerDetect", _entityData, this);
            _punishment = new Halja_Punishment(this,_stateMachine,"punishment",this);
            _whipLashes = new Halja_WhipLashes(this,_stateMachine,"whiplashes",this);
            _spawnCrow = new Halja_SpawnCrow(this,_stateMachine,"spawnCrow",this);
            //crowSpawn(false);


            _stateMachine.InitializeState(_idleState); //todo spawn state
        }

        public override void Update()
        {
            base.Update();
            if(getHealth() < (50f * this.GetComponent<Enemy>().getMaxHealth())/100f && !_secondPhase){
                Debug.Log("half life");
                _secondPhase = true;
                _iceCrow.setVulnerability(false);
                _waterCrow.setVulnerability(false);
                //_waterCrow.DestroyMinion();
                //_iceCrow.DestroyMinion();
                //waterCrowDead = true;
                //iceCrowDead = true;
                //setSpawnCrowClock(Time.time);
                //_stateMachine.ChangeState(_spawnCrow);
            }
            else if(_secondPhase && Time.time > (_crowSpawnClock + _crowSpawnCountdown)){
                if(waterCrowDead || iceCrowDead){
                    Debug.Log("time to spawn");
                    setSpawnCrowClock(Time.time);
                    _stateMachine.ChangeState(_spawnCrow);
                }
            }
            else{
                Debug.Log("nothingHappened and life is : "+ getHealth());
            }

        }

        public void crowSpawn(){
            if(iceCrowDead && waterCrowDead){
                 _iceClone = Instantiate(_IceCrowGO,new Vector3(0f,1f,0f),Quaternion.identity);
                 _waterClone = Instantiate(_WaterCrowGO);
                 _iceCrow = _iceClone.GetComponent<IceCrow>();
                 _waterCrow = _waterClone.GetComponent<WaterCrow>();
                 _iceCrow.setHalja(this);
                 _waterCrow.setHalja(this);
                 _waterCrow.setIceCrow(_iceCrow);
                 _iceCrow.setWaterCrow(_waterCrow);
                 _iceCrow.setVulnerability(true);
                _waterCrow.setVulnerability(false); 
            }
            else if(iceCrowDead){
                _iceClone = Instantiate(_IceCrowGO,new Vector3(0f,1f,0f),Quaternion.identity);
                _iceCrow = _iceClone.GetComponent<IceCrow>();
                _waterCrow.setIceCrow(_iceCrow);
                _iceCrow.setWaterCrow(_waterCrow);
                _iceCrow.setHalja(this);
                _iceCrow.setVulnerability(false);
            }
            else if(waterCrowDead){
                _waterClone = Instantiate(_WaterCrowGO);
                _waterCrow = _waterClone.GetComponent<WaterCrow>();
                _iceCrow.setWaterCrow(_waterCrow);
                _waterCrow.setIceCrow(_iceCrow);
                _waterCrow.setHalja(this);
                _waterCrow.setVulnerability(false);    
            }
            waterCrowDead = false;
            iceCrowDead = false;
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


        public GameObject instantiateProjectileChain(){
            GameObject go= Instantiate(_chainprojectile,_throwChainPosition.position,Quaternion.identity);
            return go;
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

        public bool isWaterCrowDead(){
            return waterCrowDead;
        }

        public bool isIceCrowDead(){
            return iceCrowDead;
        }


        public GameObject getChainProjectile(){
            return _chainprojectile;
        }

        #region crows-getter
        public WaterCrow GetWaterCrow(){
            return _waterCrow;
        }

         public IceCrow GetIceCrow(){
            return _iceCrow;
        }

        public GameObject GetWaterCrowGO(){
            return _WaterCrowGO;
        }

         public GameObject GetIceCrowGO(){
            return _IceCrowGO;
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


        public float getSpawnCrowCountdown(){
            return _crowSpawnCountdown;
        }

        public int getWhiplashesCycles(){
            return _whipLashesCycles;
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


        public float getSpawnCrowClock(){
            return _crowSpawnClock;
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

        public void setIceCrowDead(bool value){
            iceCrowDead = value;
        }

        public void setWaterCrowDead(bool value){
            waterCrowDead = value;
        }

        public void setWhipLashesCountdown(float time){
            _whipLashesCountdown = time;
        }

        public void setPunishmentCountdown(float time){
            _punishmentCountdown = time;
        }

        public void setChainOfDestinyCountdown(float time){
            _chainOfDestinyCountdown = time;
        }

        public void setWhipLashesCycles(int value){
            _whipLashesCycles = value;
        }


        public void setSpawnCrowClock(float time){
            _crowSpawnClock = time;
        }

        public void setHealth(float value)
        {
            _entityData.health = value;
        }

        public void setIceCrow(IceCrow crow){
            _iceCrow = crow;
        }

         public void setWaterCrow(WaterCrow crow){
            _waterCrow = crow;
        }






        #endregion

    }
}
