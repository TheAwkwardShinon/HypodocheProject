using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class Boss1 : Entity
    {
        #region Variables
        public B1_IdleState _idleState { get; private set; }
        public B1_MoveState _moveState { get; private set; }
        public B1_PlayerDetectState _playerDetectState { get; private set; }
        public B1_FistAttack _playerAttackFist { get; private set; }
        public B1_FireAttack _playerAttackFire { get; private set; }

        [SerializeField]
        private D_IdleState _idleData;
        [SerializeField]
        private D_MoveState _moveData;
        [SerializeField]
        private D_PlayerDetectState _playerDetectData;
        [SerializeField]
        private B1_D_Fire _playerAttackFireData;
        [SerializeField]
        private B1_D_Fist _playerAttackFistData;
        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();

            _moveState = new B1_MoveState(this, _stateMachine, "move", _moveData, this);
            _idleState = new B1_IdleState(this, _stateMachine, "idle", _idleData, this);
            _playerDetectState = new B1_PlayerDetectState(this, _stateMachine, "idle", _playerDetectData, this); //same animation

            // boss move set zone
            _playerAttackFist = new B1_FistAttack(this, _stateMachine, "fist", _playerAttackFistData, this);
            _playerAttackFire = new B1_FireAttack(this, _stateMachine, "fire", _playerAttackFireData, this);

            _stateMachine.InitializeState(_idleState);
        }

        #endregion
    }
}
