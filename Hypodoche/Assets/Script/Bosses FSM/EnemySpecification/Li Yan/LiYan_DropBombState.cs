using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hypodoche
{
    public class LiYan_DropBombState : State
    {
        #region Variables
        private LiYan _liYan;
        protected List<GameObject> _listOfBombs;
        protected BombSpawner _spawner;

        public LiYan_DropBombState(Entity entity, FiniteStateMachine stateMachine, string animationName, LiYan liYan)
            : base(entity, stateMachine, animationName)
        {
            _liYan = liYan;
            _listOfBombs = new List<GameObject>();
            _listOfBombs.Add(_liYan.woodBomb);
            _listOfBombs.Add(_liYan.metalBomb);
            _listOfBombs.Add(_liYan.fireBomb);
            _spawner = new BombSpawner(_listOfBombs);
        }
        #endregion

        #region Methods
        public override void Enter()
        {
            base.Enter();
            if (_entity._entityData.health <= 0)
            {
                Debug.Log("cambio stato : dropbomb -> death " + Time.time);
                _stateMachine.ChangeState(_liYan._deathState);
            }
            spawnRandomBomb();
            _liYan.timerBomb = Time.time; //restart timer
            Debug.Log("cambio stato : dropBomb -> move " + Time.time);
            //Invoke("WaitBomb", 0.1f);
            _stateMachine.ChangeState(_liYan._moveState);
        }

        void WaitBomb()
        {
            Debug.Log("^^");
            return;
        }

        public override void Exit()
        {
            base.Exit();

        }

        public void spawnRandomBomb()
        {
           _spawner.spawn(_liYan.transform.position, Quaternion.identity);
        }


        public override void Update()
        {
            base.Update();
           
        }



        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        #endregion
    }
}
