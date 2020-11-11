using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


namespace Hypodoche
{
    public class B1_PlayerDetectState : PlayerDetectState
    {
        #region Variables
        private Boss1 _boss1;
        //private List<State> moveSet;
        private List<State> usableMoveSet;

        public B1_PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_PlayerDetectState playerDetectData, Boss1 boss)
            : base(entity, stateMachine, animationName, playerDetectData)
        {
            _boss1 = boss;
            usableMoveSet = new List<State>();
        }
        #endregion


        #region Methods
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
            if (_isDetectingPlayer)
            {
                Debug.Log("player detected");
                if (_playerDetectData.aggressivity <= 20)
                    return; //_stateMachine.ChangeState(_boss1._scaredState);
                else
                {
                    /*
                    foreach (State move in moveSet)
                    {
                        if (_boss1.hittable(move.getData().angleRange, move.getData().radius, move.getData().fromRange,
                            move.getData().toRange, _playerDetectData.whatIsPlayer))
                            usableMoveSet.Add(move.Key);
                    }
                    */
                    if (_boss1._playerAttackFist.isHittable())
                    {
                        usableMoveSet.Add(_boss1._playerAttackFist);
                        Debug.Log("player in Fist range");
                    }

                    if (_boss1._playerAttackFire.isHittable())
                    {
                        usableMoveSet.Add(_boss1._playerAttackFire);
                        Debug.Log("player in Fire Range");
                    }

                    if (usableMoveSet.Count == 0) //TODO in realtà devo farlo avvicinare al player
                    {
                        Debug.Log("player out of any range");
                        _stateMachine.ChangeState(_boss1._moveState);
                        
                    }
                    else
                    {
                        _stateMachine.ChangeState(usableMoveSet[UnityEngine.Random.Range(0, usableMoveSet.Count)]); //choose a random attack
                    }
                }
            }
            else _stateMachine.ChangeState(_boss1._moveState);
        }
        #endregion
    }
}
