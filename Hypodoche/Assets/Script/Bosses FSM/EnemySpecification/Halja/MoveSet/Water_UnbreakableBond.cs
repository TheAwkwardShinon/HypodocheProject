using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Water_UnbreakableBond : State
    {
         private WaterCrow _waterCrow;
         private IceCrow _iceCrow;

         private float _begin;
        public Water_UnbreakableBond(Entity entity, FiniteStateMachine stateMachine, string animationName, WaterCrow waterCrow, IceCrow iceCrow) : base(entity, stateMachine, animationName)
        {
            _waterCrow = waterCrow;
            _iceCrow = iceCrow;
        }

        public override void Enter()
        {
            base.Enter();
            _begin = Time.time;
        }


        public override void Exit()
        {
            base.Exit();
            _waterCrow._timer = Time.time;
        }


        public override void Update()
        {
            base.Update();

            _waterCrow.Move(_waterCrow._entityData.movementSpeed);

            if(Time.time >=_begin + _iceCrow.unbreakableBondDuration){
                Debug.Log("[WaterCrow] change state unbreakabkeBond-> MoveState "+Time.time);
                _waterCrow._stateMachine.ChangeState(_waterCrow._MoveState); 
            } 
            
        }
    }
}
