using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class MoveState : State
    {
        #region Variables
        protected D_MoveState _moveData;

        protected bool isDetectingWall;
        protected bool isDetectingWind;
        protected bool isDetectingFire;
        protected bool isDetectingWater;
        protected bool isDetectingEarth;
        protected bool isSteppedOnTrap;
        #endregion

        #region Methods
        public MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_MoveState moveData)
            : base(entity, stateMachine, animationName)
        {
            _moveData = moveData;
        }

        public override void Enter()
        {
            base.Enter();
            _entity.setDirection();

            isDetectingWall = _entity.checkWall();

            /* TO BE DONE LATER
             * 
             * isDetectingWind =
             * isDetectingFire = 
             * isDetectingWater =
             * isDetectingEarth =
             * isDetectingWind =
             * isSteppedOnTrap =
             * 
             */


        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            isDetectingWall = _entity.checkWall();
            _entity.Move(_moveData.movementSpeed);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();


            isDetectingWall = _entity.checkWall();

            /* TO BE DONE LATER
             * 
             * isDetectingWind =
             * isDetectingFire = 
             * isDetectingWater =
             * isDetectingEarth =
             * isDetectingWind =
             * isSteppedOnTrap =
             * 
             */
        }

    }
    #endregion
}
