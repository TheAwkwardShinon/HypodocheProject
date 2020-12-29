using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche
{
    public class State : MonoBehaviour
    {
        #region Variables
        protected FiniteStateMachine _stateMachine;
        protected Entity _entity;
        protected float _startTime;
        protected string _animationName;
        public float elapsed = 0f;
        protected UI_AppearStatusIcon _icons;
        #endregion



        #region Methods
        public State(Entity entity, FiniteStateMachine stateMachine, string animationName)
        {
            _entity = entity;
            _stateMachine = stateMachine;
            _animationName = animationName;
            _icons = _entity._ui.GetComponent<UI_AppearStatusIcon>();
        }


        public virtual void Enter()
        {
            _startTime = Time.time;
            _entity._animator.SetBool(_animationName, true);
            Debug.Log("ANIMATION: " + _animationName);
        }

        public virtual void Exit()
        {
            _entity._animator.SetBool(_animationName, false);
        }





        public virtual void Update()
        {
            if (Time.timeScale == 0f)
                return;
            if(!_entity._minion){
                if (!_entity._entityData.slowOverArea)
                    _icons.RemoveSlow();

                if (_entity._entityData.damageOverArea)
                {
                    _entity._entityData.health -= (_entity._entityData.damageTakenOverTimeArea +(_entity._entityData.damageTakenOverTimeArea * _entity._entityData.enhanceMultiplier));
                    Enemy enemy = _entity.gameObject.GetComponent<Enemy>();
                    enemy.TakeDamage(_entity._entityData.damageTakenOverTimeArea + (_entity._entityData.damageTakenOverTimeArea * _entity._entityData.enhanceMultiplier));
                }
                else
                {
                    _icons.RemoveDmgOverTime();
                }

                if (_entity._entityData.isStun)
                {
                    if (Time.time >= _entity._entityData.timeOfStun)
                    {
                        _entity._entityData.isStun = false;
                        _entity._entityData.timeOfStun = 0;
                        _icons.RemoveStun();
                    }
                    
                }
                if (_entity._entityData.isSlowed)
                {
                    
                    if (Time.time >= _entity._entityData.timeOfSlow)
                    {
                        _entity._entityData.isSlowed = false;
                        _entity._entityData.timeOfSlow = 0;
                        _icons.RemoveSlow();
                    }
                }
                if (_entity._entityData.gotDamageOverTime)
                {
                    if (Time.time >=  _entity._entityData.timeOfDamage)
                    {
                        _entity._entityData.gotDamageOverTime = false;
                        _entity._entityData.timeOfDamage = 0;
                        _icons.RemoveDmgOverTime();
                    }
                    else
                    {
                        _entity._entityData.health -= (_entity._entityData.damageTakenOverTime + (_entity._entityData.damageTakenOverTime * _entity._entityData.enhanceMultiplier));
                        Enemy enemy = _entity.gameObject.GetComponent<Enemy>();
                        enemy.TakeDamage(_entity._entityData.damageTakenOverTime + (_entity._entityData.damageTakenOverTime * _entity._entityData.enhanceMultiplier));
                    }
                }
            }
        }

        public virtual void PhysicsUpdate()
        {

        }
        #endregion
    }
}
