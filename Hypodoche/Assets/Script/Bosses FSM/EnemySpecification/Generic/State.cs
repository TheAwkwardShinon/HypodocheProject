using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche
{
    public class State 
    {
        #region Variables
        protected FiniteStateMachine _stateMachine;
        protected Entity _entity;
        protected float _startTime;
        protected string _animationName;
        public float elapsed = 0f;
        protected UI_AppearStatusIcon _icons;

        protected AnimationWaiter _animWaiter;

        protected const string animBaseLayer = "Base Layer";
        protected MonoBehaviour _mb;

        private bool _changeState;
        #endregion



        #region Methods
        public State(Entity entity, FiniteStateMachine stateMachine, string animationName)
        {
            _entity = entity;
            _stateMachine = stateMachine;
            _animationName = animationName;
            _icons = _entity._ui.GetComponent<UI_AppearStatusIcon>();
            _animWaiter = _entity.GetComponent<AnimationWaiter>();
        }



        /*public  void WaitTillStateEnter(){
             _entity._animator.SetTrigger(_animationName);
             _animWaiter.StartCoroutine(_animWaiter.waitToEnterInTheState(_entity._animator,_animationName,this));
        }*/

        public virtual void Enter()
        {
            _entity._animator.SetTrigger(_animationName);
            //_animWaiter.StartCoroutine(_animWaiter.waitToEnterInTheState(_entity._animator,_animationName,this));
            /*while(!_changeState){
                Debug.Log("["+_animationName+"]wait to change");
            }*/
            _startTime = Time.time;
            //_entity._animator.SetBool(_animationName, true);
            //_entity._animator.SetTrigger(_animationName);
            //_animWaiter.StartCoroutine(_animWaiter.waitToEnterInTheState(_entity._animator,_animationName));
/*
            while(_animWaiter.waitToEnterInTheState(_entity._animator,_animationName).Equals(null)){
                Debug.Log("still waitingggg "+Time.time);
            }// wait to enter in teh state
            Debug.Log("exit "+Time.time);
            /*
             Debug.Log("[TRUE] ANIMATION: "+_animationName + " and now check all the coomponents values: punshment = "+
            _entity._animator.GetBool("punishment")+ " chainofdestiny = "+_entity._animator.GetBool("chainOfDestiny") +
            "  palyerdetct = "+_entity._animator.GetBool("PlayerDetect")+"   MOVE = "+_entity._animator.GetBool("run")+
            "   idle = "+_entity._animator.GetBool("idle")+"   chase = "+_entity._animator.GetBool("chase") + "last animation played/is playing: "+
            _entity._animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + " is current state's name  "+_animationName+"??? :"+
            _entity._animator.GetCurrentAnimatorStateInfo(0).tagHash.Equals(Animator.StringToHash(_animationName))
            );*/
        }

        public virtual void Exit()
        {
            //_entity._animator.SetBool(_animationName, false);
            _entity._animator.ResetTrigger(_animationName);


            /*
            Debug.Log("[FALSE] ANIMATION: "+_animationName + " and now check all the coomponents values: punshment = "+
            _entity._animator.GetBool("punishment")+ " chainofdestiny = "+_entity._animator.GetBool("chainOfDestiny") +
            "  palyerdetct = "+_entity._animator.GetBool("PlayerDetect")+"   MOVE = "+_entity._animator.GetBool("run")+
            "   idle = "+_entity._animator.GetBool("idle")+"   chase = "+_entity._animator.GetBool("chase") + "last animation played/is playing: "+
            _entity._animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + " is current state's name  "+_animationName+"??? :"+
            _entity._animator.GetCurrentAnimatorStateInfo(0).tagHash.Equals(Animator.StringToHash(_animationName))
            );*/
            
        }

        public virtual void ExecuteAfterAnimation(){

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
                        if(Time.time >= _entity._entityData.startDmgOverTime + 1f){
                            _entity._entityData.health -= (_entity._entityData.damageTakenOverTime + (_entity._entityData.damageTakenOverTime * _entity._entityData.enhanceMultiplier));
                            Enemy enemy = _entity.gameObject.GetComponent<Enemy>();
                            enemy.TakeDamage(_entity._entityData.damageTakenOverTime + (_entity._entityData.damageTakenOverTime * _entity._entityData.enhanceMultiplier));
                        }
                    }
                }
            }
        }

        public virtual void PhysicsUpdate()
        {

        }
        #endregion


        #region setter
        public void setChangeState(bool flag){
            _changeState = flag;
        }
        #endregion
    }
}
