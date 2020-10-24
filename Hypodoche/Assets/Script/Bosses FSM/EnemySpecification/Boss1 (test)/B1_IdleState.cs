using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class B1_IdleState : IdleState
{

    private Boss1 boss1;

    public  B1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_Idle idleData, Boss1 boss)
       : base(entity, stateMachine, animationName, idleData)
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

        if (isIdleTimeElapsed)
        {
            stateMachine.ChangeState(boss1.moveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
