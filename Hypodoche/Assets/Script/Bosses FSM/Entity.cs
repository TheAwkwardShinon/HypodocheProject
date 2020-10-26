using System.Collections;
using System.Collections.Generic;
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
        public int _facingDirection;
        private Vector3 _direction;
        public D_Entity _entityData;
        [SerializeField] private float _wallCheckRadius = 1f;
        [SerializeField] private LayerMask _isPerimeter;
        #endregion

        #region
        public virtual void Start()
        {

            //facingDirection = 1;
            _boss = gameObject;
            _rigidBodyBoss = _boss.GetComponent<Rigidbody>();
            _animator = _boss.GetComponent<Animator>();
            _stateMachine = new FiniteStateMachine();
        }

        public virtual void Update()
        {
            _stateMachine._currentState.Update();
        }

        public virtual void setDirection()
        {
            _direction = new Vector3(UnityEngine.Random.Range(-2f, 2f), 0,  UnityEngine.Random.Range(-2f, 2f));
        }

        public virtual void Move(float speed)
        {
            _rigidBodyBoss.position += _direction * speed * Time.fixedDeltaTime;
        }

        //mi giro di 180 gradi dal lato opposto. però sull'asse delle ascisse. Non so come gestire le ordinate, sarebbe visivamente brutto
        public virtual void Flip()
        {
            _boss.transform.Rotate(0f, 180f, 0f);
        }

        public virtual bool checkWall()
        {
            Debug.Log(Physics.OverlapSphere(_boss.transform.position, _wallCheckRadius, _isPerimeter).Length);
            return Physics.OverlapSphere(_boss.transform.position, _wallCheckRadius, _isPerimeter).Length != 0;
        }

        public virtual void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;
            Gizmos.DrawWireSphere(_boss.GetComponent<Collider>().bounds.center, _wallCheckRadius);
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
