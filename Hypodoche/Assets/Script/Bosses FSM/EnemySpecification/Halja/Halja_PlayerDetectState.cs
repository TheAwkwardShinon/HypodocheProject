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
            if (_entityData.health <= 0)
                _stateMachine.ChangeState(_halja._deathState);
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
            base.Update();
            //if(_entityData.health / 1000 <= 60){ //if has more than 60% of her life
                //todo secondPhase
            //}
           // else{
                if(_isDetectingPlayer){
                    
                    float dist = Vector3.Distance(_halja.transform.position,_playerPosition.position);
                    Debug.Log("still detecting, DIST = "+ dist+ " and min = "+_halja.getPunishmentMinDistance()+" and max= "+_halja.getPunishmentMaxDistance() );
                    if( _halja.getChainOfDestinyMinDistance() <= dist && dist <= _halja.getChainOfDestinyMaxDistance() && 
                            Time.time >= (_halja._chainOfDestinyClock + _halja.getChainOfDestinyCountdown()))
                    {
                         usableMoveSet.Add(new Halja_ChainOfDestiny(_entity, _stateMachine, "chainOfDestiny", _entityData, _halja,_playerPosition.position));
                    }   
                    if(_halja.getPunishmentMinDistance() <= dist && dist <= _halja.getPunishmentMaxDistance() &&
                            Time.time >= (_halja._punishmentClock + _halja.getPunishmentCountdown()))
                    {
                        usableMoveSet.Add(_halja._punishment);
                    }
                   if(usableMoveSet.Count > 0) _stateMachine.ChangeState(usableMoveSet[UnityEngine.Random.Range(0, usableMoveSet.Count)]);
                }
                else{
                    _playerPosition = _halja.GetIceCrow().getPlayerPosition();
                    if(_playerPosition != null){
                        Debug.Log("papapappapapapappapapapappapap");
                        _stateMachine.ChangeState(new Halja_ChaseState(_entity, _stateMachine, "chase", _entityData, _halja,_playerPosition.position));
                    }
                    _playerPosition = _halja.GetWaterCrow().getPlayerPosition();
                    if(_playerPosition != null){
                        Debug.Log("papapappapapapappapapapappapapaaa");
                        _stateMachine.ChangeState(new Halja_ChaseState(_entity, _stateMachine, "chase", _entityData, _halja,_playerPosition.position));
                    }
                    else{
                        _stateMachine.ChangeState(_halja._moveState);
                    }
                }
            //}
            
        }
    }
}
