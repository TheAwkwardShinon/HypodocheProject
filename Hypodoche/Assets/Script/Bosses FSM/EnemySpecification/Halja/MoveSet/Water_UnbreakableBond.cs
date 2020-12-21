using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Water_UnbreakableBond : State
    {
         private WaterCrow _waterCrow;
         private IceCrow _iceCrow;
        public Water_UnbreakableBond(Entity entity, FiniteStateMachine stateMachine, string animationName, WaterCrow waterCrow, IceCrow iceCrow) : base(entity, stateMachine, animationName)
        {
            _waterCrow = waterCrow;
            _iceCrow = iceCrow;
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
            if(Time.time >=_startTime + _iceCrow.getChainOfDestinyDuration())
                _waterCrow._stateMachine.ChangeState(_waterCrow.GetMoveState());  
            
        }
    }
}
