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

        public UnbreakableBond _unbreakableBond { get; private set; }

        [SerializeField] private D_IdleState _idleData;
        [SerializeField] protected IceCrow _iceCrow;
        [SerializeField] protected WaterCrow _waterCrow;

        [SerializeField] public  float unbreakableBondCountdown;
        public float timerUnbreakableBond;





        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();
            _moveState = new Halja_MoveState(this, _stateMachine, "run", _entityData, this);
            _idleState = new Halja_IdleState(this, _stateMachine, "idle", _idleData, this);
            _scareState = new Halja_ScaredState(this, _stateMachine, "run", _entityData, this);
            _deathState = new Halja_DeathState(this, _stateMachine, "death", this);
            _playerDetectState = new Halja_PlayerDetectState(this, _stateMachine, "idle", _entityData, this);
            //_chaseState = new Halja_ChaseState(this, _stateMachine, "run", _entityData, this);
            _unbreakableBond = new UnbreakableBond(this, _stateMachine, "idle", _waterCrow,_iceCrow,this);
            timerUnbreakableBond = Time.time;
            Instantiate(_iceCrow, new Vector3(0,1,0),Quaternion.identity);
            Instantiate(_waterCrow, new Vector3(0,2,0),Quaternion.identity);
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

        public float getHealth()
        {
            return _entityData.health;
        }

        #endregion
    }
}
