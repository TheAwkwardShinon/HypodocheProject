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
            _moveState = new LiYan_MoveState(this, _stateMachine, "move", _entityData, this);
            _idleState = new LiYan_IdleState(this, _stateMachine, "idle", _idleData, this);
            _scareState = new LiYan_ScaredState(this, _stateMachine, "scared", _entityData, this);
            _DropBombState = new LiYan_DropBombState(this, _stateMachine, "dropBomb", this);
            _deathState = new LiYan_DeathState(this, _stateMachine, "death", this);

            _stateMachine.InitializeState(_idleState); //todo spawn state
        }


        public void DestroyBoss()
        {
            Destroy(gameObject);
        }

        public  void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("trap"))
                stepOnTrap(col);
        }


        public  void OnTriggerExit(Collider col)
        {
            if (col.gameObject.CompareTag("trap"))
            {
                _entityData.slowOverArea = false;
                _entityData.damageOverArea = false;
                _entityData.enhanceMultiplier = 1f;
            }
        }



        public void stepOnTrap(Collider col)
        {
            _stateMachine.ChangeState(new LiYan_SufferTheEffectState(this, _stateMachine, "takeEffect", _entityData, col, "trap", this));
        }


        public float getHealth()
        {
            return _entityData.health;
        }

        #endregion
    }
}
