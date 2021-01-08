using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Caputmallei_PlayerDetectState : PlayerDetectState
    {
        #region variables
        private Caputmallei _caputmallei;
        private List<State> usableMoveSet;
        #endregion
        public Caputmallei_PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Caputmallei caputmallei) : base(entity, stateMachine, animationName, entityData)
        {
            _caputmallei = caputmallei;
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
            if (_entityData.isStun)
                return;
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_caputmallei._deathState);
            base.Update();
            if(_isDetectingPlayer){
                _caputmallei.setDirection((_playerPosition.position- _caputmallei.transform.position).normalized);
                float dist = Vector3.Distance(_caputmallei.transform.position,_playerPosition.position);
                
                if(Time.time >= (_caputmallei.getSundayMorningClock() + _caputmallei.getSundayMorningCountdown())) 
                {
                    usableMoveSet.Add(_caputmallei._sundayMorning);
                }

                if(Time.time >= (_caputmallei.getFatefulRetributionClock()+ _caputmallei.getFatefulRetributionCountdown())){
                    usableMoveSet.Add(_caputmallei._fateFulRetribution);
                }

                if(_caputmallei.getInquisitionMinDistance() <= dist && dist <= _caputmallei.getInquisitionMaxDistance() && //TODO CHANGE to not dynamic state
                            Time.time >= (_caputmallei.getInquisitionClock() + _caputmallei.getInquisitionCountdown())){
                    
                    usableMoveSet.Add(_caputmallei._inquisition);
                }

                if(usableMoveSet.Count > 0) _stateMachine.ChangeState(usableMoveSet[0]);
                else { 
                    _entity.setDirection((_playerPosition.position - _entity.transform.position).normalized); 
                    if (Vector3.Distance(_caputmallei.transform.position, _playerPosition.transform.position) >= 4f)
                        _entity.Move(_entity._entityData.movementSpeed); 
                }
            }
            else _stateMachine.ChangeState(_caputmallei._moveState);
/*
            else {

                if (_playerPosition != null)
                {
                    _stateMachine.ChangeState(new Caputmallei_ChaseState(_entity, _stateMachine, "chase", _entityData, _caputmallei, _playerPosition.position));
                }
                else
                {
                    _stateMachine.ChangeState(_caputmallei._moveState);
                }
            }*/
        } 
    }
}
