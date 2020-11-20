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
            usableMoveSet.Clear();
        }

        public override void Exit()
        {
            base.Exit();
        }



        public virtual void OntriggerEnter(Collider col)
        {
            Debug.Log("trigger");
            if (col.gameObject.CompareTag("trap"))
                stepOnTrap(col);
        }


        public virtual void stepOnTrap(Collider col)
        {
            //col.gameObject.GetComponent<objectsScriptNameHere>().variableNameHere;
            //TODO change state here
            _stateMachine.ChangeState(new SufferTheEffectState(_entity, _stateMachine, "idle", _entity._entityData, col, _boss1));
        }





        public override void Update()
        {
            base.Update();
            if (_entity._entityData.isStun)
                return;
            if (_isDetectingPlayer)
            {
                Debug.Log("player detected");
                if (_playerDetectData.aggressivity <= 20)
                    return; //_stateMachine.ChangeState(_boss1._scaredState);
                else
                {
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
                        _stateMachine.ChangeState(new B1_ChaseState(_boss1, _stateMachine, "move",_playerPosition,
                            (float)UnityEngine.Random.Range(0.2f, _entity._entityData.aggroRange), _entity._entityData, _boss1));
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
