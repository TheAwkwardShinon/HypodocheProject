using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Ice_PlayerDetectState : PlayerDetectState
    {
        #region variables
        private IceCrow _crow;
        private List<State> usableMoveSet;
        #endregion
        public Ice_PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, IceCrow crow) : base(entity, stateMachine, animationName, entityData)
        {
            _crow = crow;
            usableMoveSet = new List<State>();
        }

        public override void Enter()
        {
            base.Enter();
            usableMoveSet.Clear();
        }

        public override void Exit()
        {
            base.Exit();
        }


        public override void Update()
        {
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_crow._death);

            base.Update();

            if(Time.time >= _crow.getTimer()+ _crow.getUnBreakableBondCountDown() && _crow.GetWaterCrow() != null){
                _stateMachine.ChangeState(_crow._unbreakableBond);
            }
            
            if(_isDetectingPlayer){
                _crow.setDirection((_playerPosition.position-_crow.transform.position).normalized);
                
                float dist = Vector3.Distance(_crow.transform.position,_playerPosition.position);

                //Debug.Log("still detecting, DIST = "+ dist+ " and min = "+_halja.getPunishmentMinDistance()+" and max= "+_halja.getPunishmentMaxDistance() );
                if(_crow.getWhipLashesMinDistance() <= dist && dist <= _crow.getWhiplashesMaxDistance()&&
                        Time.time >= (_crow.getWhipLashesClock()+ _crow.getWhiplashesCountdown()))
                {
                        _stateMachine.ChangeState(_crow._whiplashes);
                } 
            }
            else{
                    _stateMachine.ChangeState(_crow._MoveState);
            }
        }
    }
}