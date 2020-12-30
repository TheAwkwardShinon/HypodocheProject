using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Halja : Entity, Boss
    {
         #region Variables
        public Halja_IdleState _idleState { get; private set; }
        public Halja_MoveState _moveState { get; private set; }
        public Halja_SufferTheEffectState _sufferEffectState { get; private set; }
        public Halja_PlayerDetectState _playerDetectState { get; private set; }
        public Halja_ChaseState _chaseState { get; private set; }
        public Halja_ScaredState _scareState { get; private set; }
        public Halja_DeathState _deathState { get; private set; }

        public Halja_ChainOfDestiny _chainOfDestiny { get; private set; }
        public Halja_Punishment _punishment { get; private set; }



        [SerializeField] private float _chainOfDestinyMaxDistance;
        [SerializeField] private float _chainOfDestinyMinDistance;

        [SerializeField] private float _punishmentMaxDistance;
        [SerializeField] private float _punishmentMinDistance;

        [SerializeField] private float _punishmentCountdown;
        [SerializeField] public  float _chainOfDestinyCountdown;

        public float _punishmentClock;
        public float _chainOfDestinyClock;



        //[SerializeField] private float _wiph;

        [SerializeField] private D_IdleState _idleData;
        [SerializeField] protected IceCrow _iceCrow;
        [SerializeField] protected WaterCrow _waterCrow;

        [SerializeField] public  float unbreakableBondCountdown;

        

        public LineRenderer lr;

        public float timerUnbreakableBond;





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
            _playerDetectState = new Halja_PlayerDetectState(this, _stateMachine, "PlayerDetect", _entityData, this);
            _punishment = new Halja_Punishment(this,_stateMachine,"punishment",this);
            //_chainOfDestiny = new Halja_ChainOfDestiny(this, _stateMachine, "chainOfDestiny", _entityData, this);

            //_chaseState = new Halja_ChaseState(this, _stateMachine, "run", _entityData, this);
            timerUnbreakableBond = Time.time;
            //Instantiate(_iceCrow, new Vector3(0,1,0),Quaternion.identity);
            //Instantiate(_waterCrow, new Vector3(0,2,0),Quaternion.identity);
            _stateMachine.InitializeState(_idleState); //todo spawn state
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
            _stateMachine.ChangeState(new Halja_SufferTheEffectState(this, _stateMachine, "takeDamage", _entityData, effect, "trap", this));
        }
        #endregion

        #region getter  
        public float getHealth()
        {
            return _entityData.health;
        }

        public WaterCrow GetWaterCrow(){
            return _waterCrow;
        }

         public IceCrow GetIceCrow(){
            return _iceCrow;
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

        #endregion

 
    }
}
