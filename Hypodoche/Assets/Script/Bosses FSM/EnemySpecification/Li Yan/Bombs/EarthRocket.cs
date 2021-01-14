using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    #region Required Components
    [RequireComponent(typeof(Rigidbody))]
    #endregion

    public class EarthRocket : MonoBehaviour, RocketInterface
    {
        [SerializeField] private float _speed = 30f;
        [SerializeField] private float _damage = 0.2f;
        [SerializeField] private float _maxDistance = 40f;

        [SerializeField] private float _stunTime = 2.5f;
        [SerializeField] private LayerMask _hitMask;
        private Rigidbody _rigidbody;
        private Vector3 _startingPosition;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = transform.forward * _speed;
            _startingPosition = transform.position;
        }
        void Update()
        {
            if ((transform.position - _startingPosition).magnitude > _maxDistance)
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_hitMask == (_hitMask | (1 << other.gameObject.layer)))
            {
                PlayerStatus status = other.GetComponent<PlayerStatus>();
                if (status != null)
                {
                    status.TakeDamage(_damage);
                    status.setStun(_stunTime,true);
                }
                Destroy(gameObject);
                return;
            }
            if(other.GetComponent<LuckyStar>() != null)
                Destroy(gameObject);
        }

        public float getDamage()
        {
            return _damage;
        }

        public void DestroyRocket(){
            Destroy(gameObject);
        }

    }
}