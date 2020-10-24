using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_Idle idleData;
    protected bool flipAfterIdle;
    protected float idleTime;
    protected bool isIdleTimeElapsed;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Idle idleData)
        : base(entity, stateMachine, animationName)
    {
        this.idleData = idleData;
    }


    public override void Enter()
    {
        base.Enter();
        entity.setVelocity(0f);
        isIdleTimeElapsed = false;
        setRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip(); //mi giro di 180 gradi dal lato opposto. peroò sull'asse delle ascisse. Non so come gestire le ordinate, sarebbe visivamente brutto
        }
    }

    public override void Update()
    {
        base.Update();
        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeElapsed = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void setFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    public void setRandomIdleTime()
    {
        idleTime = UnityEngine.Random.Range(idleData.minIdleTime, idleData.maxIdleTime);
    }
}
