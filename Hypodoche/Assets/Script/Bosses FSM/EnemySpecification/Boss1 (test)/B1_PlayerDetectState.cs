using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche
{
    public class B1_PlayerDetectState : PlayerDetectState
    {
        #region Variables
        private Boss1 _boss1;
        private Dictionary<State, ScriptableObject> moveSet;

        public B1_PlayerDetectState(Entity entity, FiniteStateMachine stateMachine, string animationName, D_PlayerDetectState playerDetectData, Boss1 boss)
            : base(entity, stateMachine, animationName, playerDetectData)
        {
            _boss1 = boss;
        }
        #endregion


        #region Methods
        public override void Enter()
        {
            base.Enter();
            moveSet = _boss1.GetMoveSet();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            /*
            if (_isDetectingPlayer)
            {
                if (_playerDetectData.aggressivity <= 20)
                    stateMachine.ChangeState(_boss1._scaredState);
                else
                {

                }
            }
            */
        }
        #endregion
    }
}
