using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class Halja_PlayerDetectState : PlayerDetectState
    {
        #region variables
        private Halja _halja;
        private List<State> usableMoveSet;
        #endregion
        public Halja_PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Halja halja) : base(entity, stateMachine, animationName, entityData)
        {
            _halja = halja;
            usableMoveSet = new List<State>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("in player detect state");
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
                _stateMachine.ChangeState(_halja._deathState);
            base.Update();

                if(_isDetectingPlayer){
                    
                    float dist = Vector3.Distance(_halja.transform.position,_playerPosition.position);
                    //Debug.Log("still detecting, DIST = "+ dist+ " and min = "+_halja.getPunishmentMinDistance()+" and max= "+_halja.getPunishmentMaxDistance() );
                    if( _halja.getChainOfDestinyMinDistance() <= dist && dist <= _halja.getChainOfDestinyMaxDistance() && 
                            Time.time >= (_halja.getChainOfDestinyClock() + _halja.getChainOfDestinyCountdown()))
                    {
                         usableMoveSet.Add(new Halja_ChainOfDestiny(_entity, _stateMachine, "chainOfDestiny", _entityData, _halja,_playerPosition.position));
                    }   
                    if(_halja.getPunishmentMinDistance() <= dist && dist <= _halja.getPunishmentMaxDistance() &&
                            Time.time >= (_halja.getPunishmentClock()+ _halja.getPunishmentCountdown()))
                    {
                        usableMoveSet.Add(_halja._punishment);
                    }
                    if(_halja.getWhipLashesMinDistance() <= dist && dist<= _halja.getWhiplashesMaxDistance() &&
                            Time.time >= (_halja.getWhipLashesClock() + _halja.getWhiplashesCountdown()))
                    {
                        usableMoveSet.Add(_halja._whipLashes);
                    }

                   if(usableMoveSet.Count > 0) _stateMachine.ChangeState(usableMoveSet[UnityEngine.Random.Range(0, usableMoveSet.Count)]);
                }
                else{
                    _playerPosition = _halja.GetIceCrow().getPlayerPosition();
                    if(_playerPosition != null){
                        _stateMachine.ChangeState(new Halja_ChaseState(_entity, _stateMachine, "chase", _entityData, _halja,_playerPosition.position));
                    }
                    _playerPosition = _halja.GetWaterCrow().getPlayerPosition();
                    if(_playerPosition != null){
                        _stateMachine.ChangeState(new Halja_ChaseState(_entity, _stateMachine, "chase", _entityData, _halja,_playerPosition.position));
                    }
                    else{
                        _stateMachine.ChangeState(_halja._moveState);
                    }
                }
                //else _stateMachine.ChangeState(_halja._moveState);
            //}
            
        }
    }
}
