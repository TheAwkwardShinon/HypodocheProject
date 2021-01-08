using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class Caputmallei : Entity,Boss
    {
        #region Variables
        public Caputmallei_IdleState _idleState { get; private set; }
        public Caputmallei_MoveState _moveState { get; private set; }
        public Caputmallei_SufferTheEffectState _sufferEffectState { get; private set; }
        //public Caputmallei_ScaredState _scareState { get; private set; }
        //public Caputmallei_DropBombState _DropBombState { get; private set; }
        public Caputmallei_DeathState _deathState { get; private set; }

        public Caputmallei_PlayerDetectState _playerDetect { get; private set; }

        public CaputMallei_FatefulRetribution _fateFulRetribution { get; private set; }

        

        public CaputMallei_SundayMorning _sundayMorning { get; private set; }

        public CaputMallei_SundayMorningExplosion _sundayMorningExplosion { get; private set; }

        public CaputMallei_Inquisition _inquisition { get; private set; }




        [SerializeField] private float _sundayMorningMinDistance;
        [SerializeField] private float _sundayMorningMaxDistance;

        [SerializeField] private float _sundayMorningCountDown;
        [SerializeField] private float _sundayMorningClock;
        
        [SerializeField] private float _sundayMorningDrurationOfCharge;

        [SerializeField] private float _sundayMorningDamage;


        [SerializeField] private float _fateFullRetributionClock;

        [SerializeField] private float _fateFullRetributionCountdown;


        [SerializeField] private float _inquisitionMinDistance;
        [SerializeField] private float _inquisitionMaxDistance;

        
        [SerializeField] private float _inquisitionClock;

        [SerializeField] private float _inquisitionCountdown;

        
        [SerializeField] private float _inquisitionDamage;

        [SerializeField] private GameObject _bloodPool;

        [SerializeField] private float _bloodPoolSpawnRdius;

        [SerializeField] private int _maxBloodPool;


        private int _bloodPoolCounter;
    
        private float _snapshotHealth;

        //bombs
        [SerializeField] private GameObject BloodyProjectile;
        [SerializeField] private D_IdleState _idleData;
        public float timerBomb;

        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();
            timerBomb = Time.time;
            _snapshotHealth = _entityData.health;
            _moveState = new Caputmallei_MoveState(this, _stateMachine, "run", _entityData, this);
            _idleState = new Caputmallei_IdleState(this, _stateMachine, "idle", _idleData, this);
            _playerDetect = new Caputmallei_PlayerDetectState(this, _stateMachine, "playerDetect", _entityData, this);
            //_DropBombState = new Caputmallei_DropBombState(this, _stateMachine, "placeBomb", this);
            _deathState = new Caputmallei_DeathState(this, _stateMachine, "death", this);
            _fateFulRetribution = new CaputMallei_FatefulRetribution(this, _stateMachine, "fateFulRetribution", this);
            _sundayMorning = new CaputMallei_SundayMorning(this, _stateMachine, "sundayMorning", this);
            _sundayMorningExplosion = new CaputMallei_SundayMorningExplosion(this, _stateMachine, "sundayMorningExplosion", this);
            _inquisition = new CaputMallei_Inquisition(this, _stateMachine, "inquisition", this);

            _stateMachine.InitializeState(_idleState); //todo spawn state
        }

        public void Update(){
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_deathState);

            if(_snapshotHealth > _entityData.health)
                instantiateBloodPool();
            _snapshotHealth = _entityData.health;

        }


        public void DestroyBoss()
        {
            Destroy(gameObject);
        }
        /*
        public  void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("trap"))
                stepOnTrap(col);
        }*/


        public  void exitFromTrap()
        {
                _entityData.slowOverArea = false;
                _entityData.damageOverArea = false;
                _entityData.enhanceMultiplier = 0f;
        }



        public void stepOnTrap(Effects effect)
        {
            _stateMachine.ChangeState(new Caputmallei_SufferTheEffectState(this, _stateMachine, "takeDamage", _entityData, effect, "trap", this));
        }


        public void instantiateBloodyProjectile(){

             Quaternion rotation = transform.rotation;
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);
            rotation *= Quaternion.Euler(0,30,0);
            Instantiate(BloodyProjectile, transform.position, rotation);

        }

        public void instantiateBloodPool(){
            if(_bloodPoolCounter <= _maxBloodPool){
                Vector3  randomPos = (Vector3) Random.insideUnitCircle * _bloodPoolSpawnRdius;
                randomPos.z = randomPos.y;
                randomPos.y = 0f;
                randomPos +=  transform.position;
                GameObject pool = Instantiate(_bloodPool, randomPos, Quaternion.identity);
                pool.GetComponent<BloodPool>().setCaputMallei(this);
                _bloodPoolCounter++;
            }
        }
        

        #endregion
        #region getters
        
        public float getHealth()
        {
            return _entityData.health;
        }

        public float getSundayMorningMinDistance(){
            return _sundayMorningMinDistance;
        }

        public float getSundayMorningMaxDistance(){
            return _sundayMorningMaxDistance;
        }

        public float getSundayMorningClock(){
            return _sundayMorningClock;
        }

        public float getSundayMorningCountdown(){
            return _sundayMorningCountDown;
        }
        
        public float getSundayMorningChargeTime(){
            return _sundayMorningDrurationOfCharge;
        }
        public float getFatefulRetributionCountdown(){
            return _fateFullRetributionCountdown;
        }

         public float getFatefulRetributionClock(){
            return _fateFullRetributionClock;
        }


        
        public float getInquisitionMinDistance(){
            return _inquisitionMinDistance;
        }

        public float getInquisitionMaxDistance(){
            return _inquisitionMaxDistance;
        }

        public float getInquisitionClock(){
            return _inquisitionClock;
        }

        public float getInquisitionCountdown(){
            return _inquisitionCountdown;
        }
        



        public GameObject getBloodyProjectile(){
            return BloodyProjectile;
        }

        public float getSundayMorningDamage(){
            return _sundayMorningDamage;
        }

        public float getInquisitionDamage(){
            return _inquisitionDamage; 
        }

        public int getBloodPoolCounter(){
            return _bloodPoolCounter;
        }


        #endregion


        #region setter
        public void setSundayMorningClock(float value){
            _sundayMorningClock = value;
        }

        public void setSundayMorningCountdown(float value){
            _sundayMorningCountDown = value;
        }

        public void setHealth(float value)
        {
            _entityData.health += value;
        }

        public void setFatefulRetributionClock(float value){
            _fateFullRetributionClock = value;
        }

        public void SetInquisitionClock(float value){
            _inquisitionClock = value;
        }

        public void setInquisitionCountdown(float value){
            _inquisitionCountdown = value;
        }
        
        public void setBloodPoolCounter(int value){
            _bloodPoolCounter = value;
        }

        #endregion
    }
}
