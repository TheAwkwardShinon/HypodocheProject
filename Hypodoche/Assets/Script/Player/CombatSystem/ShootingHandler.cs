using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class ShootingHandler : MonoBehaviour
    {
        #region Variables
        public Transform _activeShootingPoint;
        public GameObject _arrowPrefab;
        public ArrowBehaviour _arrowBehaviour;
        #endregion

        #region Getter and Setter
        public void SetActiveShootingPoint(Transform activeShootingPoint)
        {
            _activeShootingPoint = activeShootingPoint;
        }
        #endregion

        #region Method
        private void Start()
        {
            if (_arrowPrefab != null)
                _arrowBehaviour = _arrowPrefab.GetComponent<ArrowBehaviour>();
        }

        public void SetArrowStats(float dmg)
        {
            _arrowBehaviour.SetDamage(dmg);
        }

        public void Shoot()
        {
            Instantiate(_arrowPrefab, _activeShootingPoint.position, _activeShootingPoint.rotation);
        }
        #endregion
    }
}
