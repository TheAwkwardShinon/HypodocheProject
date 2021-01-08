﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Caputmallei_IdleState : IdleState
    {
        private Caputmallei _caputmallei;
        public Caputmallei_IdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_IdleState idleData, Caputmallei caputmallei) : base(entity, stateMachine, animationName, idleData)
        {
            _caputmallei = caputmallei;
        }

        public override void Enter()
        {

            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (_isIdleTimeElapsed)
            {
                _stateMachine.ChangeState(_caputmallei._moveState);
            }
        }
    }
}
