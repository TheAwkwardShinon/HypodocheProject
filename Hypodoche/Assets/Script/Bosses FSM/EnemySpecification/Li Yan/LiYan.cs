using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class LiYan : Entity,Boss
    {
        #region Variables
        public LiYan_IdleState _idleState { get; private set; }
        public LiYan_MoveState _moveState { get; private set; }
        public LiYan_SufferTheEffectState _sufferEffectState { get; private set; }
        public LiYan_ScaredState _scareState { get; private set; }
        public LiYan_DropBombState _DropBombState { get; private set; }
        public LiYan_DeathState _deathState { get; private set; }

        //bombs
        [SerializeField] public GameObject metalBomb;
        [SerializeField] public GameObject fireBomb;
        [SerializeField] public GameObject woodBomb;
        [SerializeField]
        private D_IdleState _idleData;

        public float changeSpeedToFast = 2.5f;
        public float changeSpeedToSlow = 5f;
        public float dropBombTimeRate = 7.5f;
        public float timerBomb;

        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();
            timerBomb = Time.time;
            _entityData.health = 1000f;
            _moveState = new LiYan_MoveState(this, _stateMachine, "run", _entityData, this);
            _idleState = new LiYan_IdleState(this, _stateMachine, "idle", _idleData, this);
            _scareState = new LiYan_ScaredState(this, _stateMachine, "run", _entityData, this);
            _DropBombState = new LiYan_DropBombState(this, _stateMachine, "placeBomb", this);
            _deathState = new LiYan_DeathState(this, _stateMachine, "death", this);

            _stateMachine.InitializeState(_idleState); //todo spawn state
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
            _stateMachine.ChangeState(new LiYan_SufferTheEffectState(this, _stateMachine, "takeDamage", _entityData, effect, "trap", this));
        }


        public float getHealth()
        {
            return _entityData.health;
        }

        public void setHealth(float value)
        {
            _entityData.health -= value;
        }
        

        #endregion
    }
}
