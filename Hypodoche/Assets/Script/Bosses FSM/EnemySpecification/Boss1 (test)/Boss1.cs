using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Entity
{
    public B1_IdleState idleState { get; private set; }
    public B1_MoveState moveState { get; private set; }
    [SerializeField]
    private D_Idle idleData;
    [SerializeField]
    private D_Move moveData;

    public override void Start()
    {
        base.Start();

        moveState = new B1_MoveState(this, stateMachine, "move", moveData, this);
        idleState = new B1_IdleState(this, stateMachine, "idle", idleData, this);

        stateMachine.InitializeState(moveState);
    }
}
