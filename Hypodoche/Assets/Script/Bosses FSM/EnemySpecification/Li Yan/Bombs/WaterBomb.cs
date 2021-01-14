using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : BombBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnRocketPosition;

    protected override void Explode()
    {
        Quaternion rotation = transform.rotation;
        for(int i = 0; i< 360 ; i+= 10){
            Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
            rotation *= Quaternion.Euler(0,10,0);
        }
    }
}

