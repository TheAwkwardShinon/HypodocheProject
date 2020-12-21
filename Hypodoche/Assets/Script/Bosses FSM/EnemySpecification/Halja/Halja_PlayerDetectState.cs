using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Halja_PlayerDetectState : PlayerDetectState
    {
        #region variables
        private Halja _halja;
        #endregion
        public Halja_PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Halja halja) : base(entity, stateMachine, animationName, entityData)
        {
            _halja = halja;
        }

        public override void Enter()
        {
             if (_entityData.health <= 0)
                _stateMachine.ChangeState(_halja._deathState);
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }


        public override void Update()
        {
            if (_entityData.isStun)
                return;
            base.Update();
        }
    }
}
