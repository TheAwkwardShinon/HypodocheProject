using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(Rigidbody))]
    #endregion

    public class ArrowBehaviour : MonoBehaviour, RocketInterface
    {
        #region Variables
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _damage = 10;
        [SerializeField] private float _maxDistance = 20f;
        [SerializeField] private LayerMask _mouseMask;
        private Rigidbody _rigidbody;
        private Vector3 _startingPosition;
        #endregion

        #region Getter and Setter
        public void SetDamage(float damage)
        {
            _damage = damage;
        }
        #endregion

        #region Methods
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _mouseMask))
            {
                Vector3 target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(target);
            }

            _rigidbody.velocity = transform.forward * _speed;
            _startingPosition = transform.position;
        }

        private void Update()
        {
            if ((transform.position - _startingPosition).magnitude > _maxDistance)
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject hitParent = other.transform.root.gameObject;
            Enemy enemy = hitParent.GetComponent<Enemy>();
            
            if (!other.gameObject.CompareTag("Player"))
            {
                if(other.gameObject.CompareTag("trap")){
                    return;
                }
                if (enemy != null)
                {
                    enemy.TakeDamage(_damage);
                }
                Destroy(gameObject);
            }
        }

        public float getDamage()
        {
            return _damage;
        }

        public void DestroyRocket()
        {
            Destroy(gameObject);
        }
        #endregion
    }
}