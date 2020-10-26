using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class Boss1 : Entity
    {
        #region Variables
        public B1_IdleState _idleState { get; private set; }
        public B1_MoveState _moveState { get; private set; }
        [SerializeField]
        private D_IdleState _idleData;
        [SerializeField]
        private D_MoveState _moveData;
        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();

            _moveState = new B1_MoveState(this, _stateMachine, "move", _moveData, this);
            _idleState = new B1_IdleState(this, _stateMachine, "idle", _idleData, this);

            _stateMachine.InitializeState(_moveState);
        }
        #endregion
    }
}