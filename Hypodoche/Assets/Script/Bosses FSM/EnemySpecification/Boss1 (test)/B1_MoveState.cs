using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_MoveState : MoveState
{
    private Boss1 boss1;

    public  B1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Move moveData, Boss1 boss)
        : base(entity, stateMachine, animationName, moveData) 
    {
        this.boss1 = boss;
    }


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
        if (isDetectingWall)
        {
            boss1.idleState.setFlipAfterIdle(true);
            stateMachine.ChangeState(boss1.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }



}
