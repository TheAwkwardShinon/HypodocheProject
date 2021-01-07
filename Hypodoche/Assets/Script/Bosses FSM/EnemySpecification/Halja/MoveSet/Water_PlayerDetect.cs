using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Water_PlayerDetectState : PlayerDetectState
    {
        #region variables
        private WaterCrow _crow;
        private List<State> usableMoveSet;
        #endregion
        public Water_PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, WaterCrow crow) : base(entity, stateMachine, animationName, entityData)
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
            if(_isDetectingPlayer){
                _crow.setDirection((_playerPosition.position-_crow.transform.position).normalized);
                
                float dist = Vector3.Distance(_crow.transform.position,_playerPosition.position);

                //Debug.Log("still detecting, DIST = "+ dist+ " and min = "+_halja.getPunishmentMinDistance()+" and max= "+_halja.getPunishmentMaxDistance() );
                if( _crow.getChainOfDestinyMinDistance() <= dist && dist <= _crow.getChainOfDestinyMaxDistance() && 
                        Time.time >= (_crow.getChainOfDestinyClock() + _crow.getChainOfDestinyCountdown()))
                {
                        usableMoveSet.Add(new Water_ChainOfDestiny(_entity, _stateMachine, "chainOfDestiny", _entityData, _crow ,_playerPosition.position));
                }   
                if(_crow.getPunishmentMinDistance() <= dist && dist <= _crow.getPunishmentMaxDistance() &&
                        Time.time >= (_crow.getPunishmentClock()+ _crow.getPunishmentCountdown()))
                {
                    /*
                    Vector3 characterToCollider = (_playerPosition.position-_halja.transform.position).normalized;
                    float dot = Vector3.Dot(characterToCollider, _halja.transform.forward*-1f);
                    if(dot > 0.5)*/
                        usableMoveSet.Add(_crow._punishment);
                } 
                if(usableMoveSet.Count > 0) _stateMachine.ChangeState(usableMoveSet[UnityEngine.Random.Range(0, usableMoveSet.Count)]);

                else{
                    _entity.setDirection((_playerPosition.position- _entity.transform.position).normalized);
                    if(Vector3.Distance(_crow.transform.position,_playerPosition.transform.position) >= 5f)
                        _entity.Move(_entity._entityData.movementSpeed);
                }
            }
            else{
                    _stateMachine.ChangeState(_crow._MoveState);
            }
        }
    }
}
