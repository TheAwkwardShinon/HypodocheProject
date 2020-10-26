using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rigidBodyBoss { get; private set; }
    public Animator animator { get; private set; }
    public GameObject boss { get; private set; }
    public FiniteStateMachine stateMachine;
    public int facingDirection;
    private Vector2 velocityWorkspace;
    public D_Entity entityData;
    [SerializeField]
    private Transform wallCheck;

    public virtual void Start()
    {
        
        //facingDirection = 1;
        boss = gameObject;
        rigidBodyBoss = boss.GetComponent<Rigidbody2D>();
        animator = boss.GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.Update();
    }

    public virtual void setVelocity(float velocity)
    {
        velocityWorkspace.Set(UnityEngine.Random.Range(-2f,2f) * velocity, UnityEngine.Random.Range(-2f, 2f) * velocity);
        rigidBodyBoss.velocity = velocityWorkspace;
    }

    //mi giro di 180 gradi dal lato opposto. però sull'asse delle ascisse. Non so come gestire le ordinate, sarebbe visivamente brutto
    public virtual void Flip()
    {
        boss.transform.Rotate(0f, 180f, 0f);
    }

    public virtual bool checkWall()
    {
        return Physics2D.Raycast(boss.transform.position, velocityWorkspace, entityData.wallCheckRange, entityData.whatIsPerimeter);

        /*
         * 
        if (Physics.OverlapSphere(boss.transform.position, entityData.wallCheckRange, entityData.whatIsPerimeter).Length == 0)
            return false;
        return true; 
        
         */
    }



    /* Functions to be done later */
    public virtual bool checkFire()
    {
        return true;
    }

    public virtual bool checkWater()
    {
        return true;
    }

    public virtual bool checkWind()
    {
        return true;
    }

    public virtual bool checkEarth()
    {
        return true;
    }

    public virtual bool stepOnTrap()
    {
        return true;
    }
}
