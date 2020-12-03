using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Hypodoche
{
    public class FireBombBehaviour : BombBehaviour
    {
        #region Variables
        [SerializeField] private VisualEffect _explosion;
        [SerializeField] private float _explosionRadius = 2f;
        #endregion

        #region Methods
        private void Start()
        {
            _explosion.enabled = false;
            
        }

        protected override void Explode()
        {
            _explosion.enabled = true;
            _spriteRenderer.enabled = false;
            Collider[] hitObjects = Physics.OverlapSphere(transform.position, _explosionRadius, _hitMask);

            foreach (Collider obj in hitObjects)
            {
                PlayerStatus status = obj.GetComponent<PlayerStatus>();

                if (status != null)
                    status.TakeDamage(_bombDamage);
            }
        }

        private void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Player"))
                Explode();
        }
        #endregion
    }
}
