using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class MetalBombBehaviour : BombBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _spawnRocketPosition;

        protected override void Explode()
        {
            Instantiate(_projectilePrefab, _spawnRocketPosition.position, Quaternion.identity);
        }
    }
}
