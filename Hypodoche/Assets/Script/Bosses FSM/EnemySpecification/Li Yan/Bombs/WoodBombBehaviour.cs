using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBombBehaviour : BombBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnRocketPosition;

    protected override void Explode()
    {
        Quaternion rotation = transform.rotation;
        Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
        rotation *= Quaternion.Euler(0,90,0);
        Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
        rotation *= Quaternion.Euler(0,90,0);
        Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
        rotation *= Quaternion.Euler(0,90,0);
        Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
    }
}
