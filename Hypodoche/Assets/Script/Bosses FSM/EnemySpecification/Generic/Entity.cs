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
        [SerializeField] public GameObject _ui;
        #endregion

        #region
        public virtual void Start()
        {
            resetStates();
            _boss = gameObject;
            _rigidBodyBoss = _boss.GetComponent<Rigidbody>();
            _animator = _boss.transform.GetChild(0).GetComponent<Animator>();
            _stateMachine = new FiniteStateMachine();
            resetValues();
        }

        public virtual void Update()
        {
            _stateMachine._currentState.Update();
        }



        public void resetValues()
        {
            _entityData.slowOverArea = false;
            _entityData.damageOverArea = false;
            _entityData.enhanceMultiplier = 0f;
            _entityData.health = 250f;
        }

        public virtual void setDirection()
        {
            _direction = new Vector3(UnityEngine.Random.Range(-1.0f,1.0f),0,UnityEngine.Random.Range(-1.0f, 1.0f));    
        }

        /*public virtual void FixedUpdate()
        {
            _rigidBodyBoss.velocity = Vector3.zero;
        }*/
        
        public virtual void Move(float speed)
        {
            _rigidBodyBoss.MovePosition(_rigidBodyBoss.position + _direction * speed * Time.fixedDeltaTime);
            //_boss.transform.position += _direction * speed * Time.fixedDeltaTime;
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


        public virtual Transform isPlayerInAggroRange()
        {
            Collider[] player = Physics.OverlapSphere(_boss.transform.position, _entityData.aggroRange, _entityData.whatIsPlayer);
            if (player.Length == 0)
                return null;
            else return player[0].transform;
        }



        // non ho la minima idea di come farlo vedere in gizmos, ma dovrebbe essere giusto.
        public virtual bool hittable(float viewAngle, float radius, float from, float to, LayerMask targetMask) //radius < viewRadius
        {
            Debug.Log("Checking attack range...");
            radius = radius <= _entityData.aggroRange ? radius : _entityData.aggroRange;
            Collider[] targetsInViewRadius = Physics.OverlapSphere(_boss.transform.position, radius, targetMask);
            if (targetsInViewRadius.Length == 0)
                return false;
            Transform target = targetsInViewRadius[0].transform;
            Vector3 dirToTarget = (target.position - _boss.transform.position).normalized;
            if (Vector3.Angle(_boss.transform.forward * from, dirToTarget) < viewAngle)
            {
                float dstToTarget = Vector3.Distance(_boss.transform.position, target.position);
                if (dstToTarget <= to)
                    return true;
            }
            return false;
        }


        public virtual void OnDrawGizmos() { 
            if (!Application.isPlaying)
                return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_boss.GetComponent<Collider>().bounds.center, _entityData.aggroRange);
        }


        public void resetStates()
        {
            _entityData.isStun = false;
            _entityData.timeOfStun = 0f;
            _entityData.isSlowed = false;
            _entityData.timeOfSlow = 0f;
            _entityData.gotDamageOverTime = false;
            _entityData.timeOfDamage = 0f;
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

       
        #endregion
    }
}
