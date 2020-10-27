﻿using System.Collections;
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
        public void SetArrowStats(Weapon weapon)
        {
            _arrowBehaviour.SetDamage(weapon.GetLightDamage());
        }

        public void Shoot()
        {
            Instantiate(_arrowPrefab, _activeShootingPoint.position, _activeShootingPoint.rotation);
        }
        #endregion
    }
}
