﻿using System.Collections;
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



        public override void ExecuteAfterAnimation()
        {
            base.ExecuteAfterAnimation();
            if (_entity._entityData.health <= 0)
            {
                _stateMachine.ChangeState(_liYan._deathState);
            }
            spawnRandomBomb();
            _liYan.timerBomb = Time.time; //restart timer
            _stateMachine.ChangeState(_liYan._moveState);
        }
        public override void Enter()
        {
            base.Enter();
            _animWaiter.StartCoroutine(_animWaiter.waitTillTheAnimationEnds(_entity._animator,this));

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
