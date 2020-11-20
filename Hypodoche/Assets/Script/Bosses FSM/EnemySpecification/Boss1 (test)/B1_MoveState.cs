using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class B1_MoveState : MoveState
    {
        #region Variables
        private Boss1 _boss1;
        public B1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Entity entityData, Boss1 boss)
            : base(entity, stateMachine, animationName, entityData)
        {
            _boss1 = boss;
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
            if (_entityData.isStun)
                return;
            if (_isDetectingWall)
            {
                _boss1._idleState.setFlipAfterIdle(true);
                _stateMachine.ChangeState(_boss1._idleState);
            }
            else if (_isDetectingPlayer)
                _stateMachine.ChangeState(_boss1._playerDetectState);
            else
            {
                if (_entityData.isSlowed)
                    _boss1.Move(_entityData.speedWhenSlowed);
                else if (_entityData.isStun)
                    return;
                else _boss1.Move(_entityData.movementSpeed);
            }
        }



        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        #endregion
    }
}
