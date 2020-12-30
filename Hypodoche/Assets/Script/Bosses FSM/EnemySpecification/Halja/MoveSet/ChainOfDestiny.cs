using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class ChainOfDestiny : State
    {
        private D_Entity _data;
        public ChainOfDestiny(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData) : base(entity, stateMachine, animationName)
        {
            _data = entityData;
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
        }
    }
}
