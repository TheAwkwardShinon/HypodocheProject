using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_Move moveData;

    protected bool isDetectingWall;
    protected bool isDetectingWind;
    protected bool isDetectingFire;
    protected bool isDetectingWater;
    protected bool isDetectingEarth;
    protected bool isSteppedOnTrap;


    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName,D_Move moveData)
        : base(entity, stateMachine, animationName)
    {
        this.moveData = moveData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.setVelocity(moveData.movementSpeed);

        isDetectingWall = entity.checkWall();

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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();


        isDetectingWall = entity.checkWall();

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
