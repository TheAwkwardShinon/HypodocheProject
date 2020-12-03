using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected LayerMask _hitMask;
    [SerializeField] protected float _bombDamage = 15f;
    protected Animator _animator;
    protected float _timeToExplode;
    protected float _timeToAccelerate;
    protected float _timeToDestroy;
    [SerializeField] protected float _chargeTime = 4f;
    [SerializeField] protected float _explosionDelay = 2f;
    protected int _accelerateTriggerHash;
    protected bool _exploded = false;

    protected void TriggerSecondPhase()
    {
        _animator.SetTrigger(_accelerateTriggerHash);
    }

    protected void Awake(){
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _timeToAccelerate = Time.time + (_chargeTime / 2);
        _timeToExplode = Time.time + _chargeTime;
        _timeToDestroy = _timeToExplode + _explosionDelay;
        _accelerateTriggerHash = Animator.StringToHash("ReadyToExplode");
    }

    protected void Update()
    {
        if (Time.time > _timeToAccelerate)
            TriggerSecondPhase();
        if (Time.time > _timeToExplode && !_exploded){
            _exploded = true;
            Explode();
        }
        if (Time.time > _timeToDestroy)
            Object.Destroy(gameObject);
    }

    protected virtual void Explode(){}
}
