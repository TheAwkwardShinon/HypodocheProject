using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class Entity : MonoBehaviour
    {
        #region Variables
        public Rigidbody _rigidBodyBoss { get; private set; }
        public Animator _animator { get; private set; }
        public GameObject _boss { get; private set; }
        public FiniteStateMachine _stateMachine;
        private Vector3 _direction;
        public D_Entity _entityData;
        #endregion

        #region
        public virtual void Start()
        {

            //facingDirection = 1;
            _boss = gameObject;
            _rigidBodyBoss = _boss.GetComponent<Rigidbody>();
            _animator = _boss.transform.GetChild(0).GetComponent<Animator>();
            _stateMachine = new FiniteStateMachine();
        }

        public virtual void Update()
        {
            _stateMachine._currentState.Update();
        }

        public virtual void setDirection()
        {
            _direction = new Vector3(UnityEngine.Random.Range(-1.0f,1.0f),0,UnityEngine.Random.Range(-1.0f, 1.0f));    
        }

        
        public virtual void Move(float speed)
        {
            _boss.transform.position += _direction * speed * Time.fixedDeltaTime;
        }

        //mi giro di 180 gradi dal lato opposto. però sull'asse delle ascisse. Non so come gestire le ordinate, sarebbe visivamente brutto
        public virtual void Flip()
        {
            _boss.transform.Rotate(0f, 0f, 180f);
        }

        public virtual bool checkWall()
        {

            Debug.DrawRay(_boss.transform.position, _direction * _entityData.wallCheckRange, Color.yellow);
            return Physics.Raycast(_boss.transform.position, _direction, _entityData.wallCheckRange, _entityData.whatIsPerimeter);
        }


        public virtual bool isPlayerInAggroRange()
        {
            return Physics.OverlapSphere(_boss.transform.position, _entityData.aggroRange, _entityData.whatIsPlayer).Length != 0;
        }


  

        
        public virtual void OnDrawGizmos() { 
            if (!Application.isPlaying)
                return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_boss.GetComponent<Collider>().bounds.center, _entityData.aggroRange);
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
        #endregion
    }
}
