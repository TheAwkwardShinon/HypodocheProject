using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBomb : BombBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnRocketPosition;

    [SerializeField] private Transform _forceFirstRocket;
    [SerializeField] private Transform _forceSecondRocket;



    protected override void Explode()
    {
        Quaternion rotation = transform.rotation;
        rotation *= Quaternion.Euler(0,45,0);
        GameObject first = Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
        rotation *= Quaternion.Euler(0,135,0);
        GameObject second = Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
        rotation *= Quaternion.Euler(0,225,0);
        Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);
        rotation *= Quaternion.Euler(0,315,0);
        Instantiate(_projectilePrefab, _spawnRocketPosition.position, rotation);

                //first.GetComponent<Rigidbody>().AddExplosionForce(2f,_forceFirstRocket.position,4f,1f,ForceMode.Force);
        //second.GetComponent<Rigidbody>().AddExplosionForce(2f,_forceSecondRocket.position,4f,1f,ForceMode.Force);
    }
}

