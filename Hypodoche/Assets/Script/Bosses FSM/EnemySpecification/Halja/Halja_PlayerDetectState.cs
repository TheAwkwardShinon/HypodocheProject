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
      // if(_halja.getHealth() < (50f * _halja.GetComponent<Enemy>().getMaxHealth())/100f){ //se ha meno della metà della vita
                /*
                if()
                _halja.GetIceCrow().setVulnerability(true);
                _halja.GetWaterCrow().setVulnerability(true);
                */
        //    }
           // else{
                if(_isDetectingPlayer){
                    _halja.setDirection((_playerPosition.position-_halja.transform.position).normalized);
                    
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
                        /*
                        Vector3 characterToCollider = (_playerPosition.position-_halja.transform.position).normalized;
                        float dot = Vector3.Dot(characterToCollider, _halja.transform.forward*-1f);
                        if(dot > 0.5)*/
                            usableMoveSet.Add(_halja._punishment);
                    }
                    if(_halja.getWhipLashesMinDistance() <= dist && dist<= _halja.getWhiplashesMaxDistance() &&
                            Time.time >= (_halja.getWhipLashesClock() + _halja.getWhiplashesCountdown()))
                    {
                        usableMoveSet.Add(_halja._whipLashes);
                    }

                   if(usableMoveSet.Count > 0) _stateMachine.ChangeState(usableMoveSet[UnityEngine.Random.Range(0, usableMoveSet.Count)]);

                   else{
                       _entity.setDirection((_playerPosition.position- _entity.transform.position).normalized);
                       if(Vector3.Distance(_halja.transform.position,_playerPosition.transform.position) >= 5f){
                            if(_entity._entityData.isSlowed)
                                _entity.Move(_entity._entityData.speedWhenSlowedArea);
                            else _entity.Move(_entity._entityData.movementSpeed);
                       }
                   }
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
            //}
                //else _stateMachine.ChangeState(_halja._moveState);
            //}
            
        }
    }
}
