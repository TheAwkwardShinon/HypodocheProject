using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    #region Required Components
    [RequireComponent(typeof(Rigidbody))]
    #endregion

    public class SimpleRocketBehaviour : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _damage = 30f;
        [SerializeField] private float _maxDistance = 20f;
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
                }
                Destroy(gameObject);
            }
        }
    }
}
