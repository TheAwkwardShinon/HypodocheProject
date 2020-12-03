using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{

    #region Required Components
    [RequireComponent(typeof(Rigidbody))]
    #endregion
    
    public class MetalRocketBehaviour : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _damage = 30f;
        [SerializeField] private float _maxDistance = 20f;
        [SerializeField] private GameObject _sideRocket;
        private float _spawnSideRocketsTime;
        private Rigidbody _rigidbody;
        private Vector3 _startingPosition;
        #endregion

        //TODO Rimuovi
        Transform player;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            player.position = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(player.position);
            
            _rigidbody.velocity = transform.forward * _speed;
            _startingPosition = transform.position;
            _spawnSideRocketsTime = Time.time + 2f;
        }

        void Update()
        {
            if ((transform.position - _startingPosition).magnitude > _maxDistance)
                Destroy(gameObject);
            if (Time.time > _spawnSideRocketsTime && _sideRocket != null)
                _spawnSideRockets();
        }

        private void _spawnSideRockets(){
            _spawnSideRocketsTime = Time.time + 2f;
            GameObject newRocket = Instantiate(_sideRocket, transform.position, Quaternion.identity);
            newRocket.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Bomb"))
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

