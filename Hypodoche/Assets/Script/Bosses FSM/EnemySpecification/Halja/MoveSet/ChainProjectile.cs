using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class ChainProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _damage = 0.5f;
        [SerializeField] private float _maxDistance = 14f;
        [SerializeField] private LayerMask _hitMask;

        private Vector3 _direction;
        private Rigidbody _rigidbody;
        private Vector3 _startingPosition;

        private bool _moveBack = false;

        private GameObject _player;

        private bool _hit = false;

        private Vector3 _haljaPosition;

        void Start()
        {
            //_rigidbody.velocity = _direction * _speed;

        }
        void Update()
        {
            if (Vector3.Distance(_startingPosition,transform.position) > _maxDistance)
                Object.Destroy(gameObject);

            else if(_hit){
                _player.transform.position = Vector3.MoveTowards(_player.transform.position,_haljaPosition, 30f * Time.deltaTime);
                if(Vector3.Distance(_startingPosition,transform.position)<=0.5f){
                     Object.Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_hitMask == (_hitMask | (1 << other.gameObject.layer)))
            {
                PlayerStatus status = other.GetComponent<PlayerStatus>();
                _player = other.gameObject;
                
                if (status != null)
                {
                    status.TakeDamage(_damage);
                    status.setStun(2f,true);
                    _direction = (_startingPosition - transform.position).normalized;
                    _rigidbody.velocity = _direction * _speed;
                    _hit= true;
                }

                return;
            }
        }

        public float getDamage()
        {
            return _damage;
        }

    
        public void setTarget(Vector3 playerPosition, Vector3 haljaPosition){
            _startingPosition = transform.position;
            _direction = (playerPosition - transform.position).normalized;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = _direction * _speed;
            _haljaPosition = haljaPosition;
        }

        #region getters

        public bool hitPlayer(){
            return _hit;
        }

        #endregion
    
    }
}
