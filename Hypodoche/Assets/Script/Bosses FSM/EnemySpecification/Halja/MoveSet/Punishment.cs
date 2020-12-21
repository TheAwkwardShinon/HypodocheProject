using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Punishment : State
    {
        public Punishment(Entity entity, FiniteStateMachine stateMachine, string animationName) : base(entity, stateMachine, animationName)
        {
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
