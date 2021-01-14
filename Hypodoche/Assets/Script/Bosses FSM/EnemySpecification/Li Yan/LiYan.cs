using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class LiYan : Entity,Boss
    {
        #region Variables
        public LiYan_IdleState _idleState { get; private set; }
        public LiYan_MoveState _moveState { get; private set; }
        public LiYan_SufferTheEffectState _sufferEffectState { get; private set; }
        public LiYan_ScaredState _scareState { get; private set; }
      
        public LiYan_DeathState _deathState { get; private set; }

        //bombs
        [SerializeField] private GameObject metalBomb;
        [SerializeField] private GameObject fireBomb;
        [SerializeField] private GameObject woodBomb;

        [SerializeField] private GameObject waterBomb;

         [SerializeField] private GameObject earthBomb;
        protected List<GameObject> _listOfBombs;
        [SerializeField] private D_IdleState _idleData;

        [SerializeField] private float changeSpeedToFast = 6f;
        [SerializeField] private float changeSpeedToSlow = 15f;
        [SerializeField] private float dropBombTimeRate = 7.5f;

        [SerializeField] private float _slowSpeed;

        [SerializeField] private float _fastSpeed;
        private  float timerBomb;

        #endregion

        #region Methods
        public override void Start()
        {
            base.Start();
            timerBomb = Time.time;
            _entityData.health = 1000f;
            _listOfBombs = new List<GameObject>();
            _moveState = new LiYan_MoveState(this, _stateMachine, "run", _entityData, this);
            _idleState = new LiYan_IdleState(this, _stateMachine, "idle", _idleData, this);
            _scareState = new LiYan_ScaredState(this, _stateMachine, "run", _entityData, this);
            _deathState = new LiYan_DeathState(this, _stateMachine, "death", this);
            _listOfBombs.Add(woodBomb);
            _listOfBombs.Add(metalBomb);
            _listOfBombs.Add(fireBomb);
            _listOfBombs.Add(waterBomb);
            _listOfBombs.Add(earthBomb);
            _stateMachine.InitializeState(_idleState); //todo spawn state

        }


        public override void Update()
        {
            base.Update();
            //_spawner.spawn(_liYan.transform.position, Quaternion.identity);
            if (Time.time >= timerBomb + dropBombTimeRate)
            {
                Instantiate(_listOfBombs[UnityEngine.Random.Range(0, _listOfBombs.Count)], transform.position, Quaternion.identity);
                timerBomb = Time.time; //restart timer
            }
        }


        public void DestroyBoss()
        {
            Destroy(gameObject);
        }
        /*
        public  void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("trap"))
                stepOnTrap(col);
        }*/


        public  void exitFromTrap()
        {
                _entityData.slowOverArea = false;
                _entityData.damageOverArea = false;
                _entityData.enhanceMultiplier = 0f;
        }



        public void stepOnTrap(Effects effect)
        {
            Debug.Log("sto per entrare in suffere The Effect");
            _stateMachine.ChangeState(new LiYan_SufferTheEffectState(this, _stateMachine, "takeDamage", _entityData, effect, "trap", this));
        }


        public float getHealth()
        {
            return _entityData.health;
        }

        public void setHealth(float value)
        {
            _entityData.health -= value;
        }

        public float getFastSpeed(){
            return _fastSpeed;
        }

        public float getSlowSpeed(){
            return _slowSpeed;
        }


        public float getSlowClock(){
            return changeSpeedToSlow;
        }

        public float getFastClock(){
            return changeSpeedToFast;
        }

        #endregion
    }
}
