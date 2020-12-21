using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche {
    public class Ice_UnbreakableBond : State
    {
        private IceCrow _iceCrow;
        private WaterCrow _waterCrow;

        public Ice_UnbreakableBond(Entity entity, FiniteStateMachine stateMachine, string animationName, WaterCrow waterCrow, IceCrow iceCrow) : base(entity, stateMachine, animationName)
        {
            _waterCrow = waterCrow;
            _iceCrow = iceCrow;
        }

        public override void Enter()
        {
            base.Enter();
           Instantiate(_iceCrow._chain,_iceCrow.transform.position, 
                        Quaternion.LookRotation(Vector3.Lerp(_iceCrow.transform.position,_waterCrow.transform.position,0.5f)));
           _iceCrow._chain.transform.localScale = new Vector3(2f,Vector3.Distance(_iceCrow.transform.position, _waterCrow.transform.position),0f);
        }

        public override void Exit()
        {
            base.Exit();
        }


        public override void Update()
        {
            base.Update();
            if(Time.time >=_startTime + _iceCrow.getChainOfDestinyDuration()){
                Destroy(_iceCrow._chain);
                _iceCrow._stateMachine.ChangeState(_iceCrow.GetMoveState());  
            }              
        }
    }
}
