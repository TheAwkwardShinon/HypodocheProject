using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class Halja_Punishment : State
    {
        private Halja _halja;

        public Vector3 leftLine;
        public Vector3 rightLine;

        private Collider _player;

        private bool _hit;
        public Halja_Punishment(Entity entity, FiniteStateMachine stateMachine, string animationName,Halja halja) : base(entity, stateMachine, animationName)
        {
            _halja = halja;
        }

        public override void Enter()
        {
            Collider[] player = Physics.OverlapSphere(_halja.transform.position,10f,LayerMask.GetMask("Player"));
            _player = player.Length == 0 ? null : player[0];
            if(_player == null){
                _hit = false;
            }
            else{
                leftLine = Quaternion.Euler(0,45,0) * _halja.transform.forward;
                rightLine = Quaternion.Euler(0,-45,0) * _halja.transform.forward;
              //  Debug.Log("the angle is 90? : " + Vector3.Angle(rightLine, leftLine));
               // Debug.Log("i've got the player: "+_player);
               _hit = true;  
            }
            base.Enter();
             _stateMachine.ChangeState(_halja._moveState);
            
        }

        public override void Exit()
        {
            base.Exit();
            if(_hit){ //colpisco a fine aniamzione obv
                _player.GetComponent<Rigidbody>().AddForce(_halja.getDirection()*15f,ForceMode.Impulse);
                _player.GetComponent<PlayerStatus>().TakeDamage(2f);
            }
            _halja._punishmentClock = Time.time;
        }

 

        public override void Update()
        {
            base.Update();
             Debug.DrawRay(_halja.transform.position, leftLine, Color.red);
                Debug.DrawRay(_halja.transform.position, rightLine, Color.red);
          
        }
    }
}
