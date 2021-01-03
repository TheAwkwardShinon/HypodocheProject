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


        public override void ExecuteAfterAnimation(){
            base.ExecuteAfterAnimation();
            Collider[] player = Physics.OverlapSphere(_halja.transform.position,_halja.getPunishmentMaxDistance()/2,LayerMask.GetMask("Player"));
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
            if(_hit){ //colpisco a fine aniamzione obv
                _player.GetComponent<Rigidbody>().AddForce(_halja.getDirection()*8f,ForceMode.Impulse);
                _player.GetComponent<PlayerStatus>().TakeDamage(2f);
                _halja._punishmentClock = Time.time;
            }
             _stateMachine.ChangeState(_halja._moveState);
        }

        public override void Enter()
        {
            base.Enter();
            _hit = false;
            _animWaiter.StartCoroutine(_animWaiter.waitSomeSeconds(this,0.4f)); //wait the end of teh aniamtion!   
        }

        public override void Exit()
        {
            base.Exit();
        }

 

        public override void Update()
        {
            base.Update();
            //Debug.DrawRay(_halja.transform.position, leftLine, Color.red);
            //Debug.DrawRay(_halja.transform.position, rightLine, Color.red);
          
        }
    }
}
