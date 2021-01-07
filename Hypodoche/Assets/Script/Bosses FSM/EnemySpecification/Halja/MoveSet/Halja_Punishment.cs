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
         
            if(_hit){ //colpisco a fine aniamzione obv
                //_player.GetComponent<Rigidbody>().AddForce(_halja.getDirection()*8f,ForceMode.Impulse);
                _player.GetComponent<Rigidbody>().AddExplosionForce(40f,_halja.transform.position,7f,0f,ForceMode.Impulse);
                _player.GetComponent<PlayerStatus>().TakeDamage(10f);
            }
            _halja.setPunishmentCountdown(5f);
            _halja.setPunishmentClock(Time.time);
            _halja.setChainOfDestinyClock(2.5f);
            _halja.setChainOfDestinyClock(Time.time);
            _halja.setWhipLashesCountdown(4f);
            _halja.setWhipLashesClock(Time.time);
            _stateMachine.ChangeState(_halja._moveState);
        }

        public override void Enter()
        {
            base.Enter();
            _hit = false;
            Collider[] player = Physics.OverlapSphere(_halja.transform.position,_halja.getPunishmentMaxDistance(),LayerMask.GetMask("Player"));
            _player = player.Length == 0 ? null : player[0];
            if(_player == null){
                _hit = false;
            }
            else{
                _hit = true;
               // leftLine = Quaternion.Euler(0,45,0) * _halja.getDirection();;
                //rightLine = Quaternion.Euler(0,-45,0) * _halja.getDirection();
              //  Debug.Log("the angle is 90? : " + Vector3.Angle(rightLine, leftLine));
               // Debug.Log("i've got the player: "+_player);
 /*
                Vector3 characterToCollider = (_player.transform.position-_halja.transform.position).normalized;
                float dot = Vector3.Dot(characterToCollider, _halja.transform.forward*-1f);
                if(dot < 0.5)
                    _hit = false;
                if (dot >= Mathf.Cos(55))
                        _hit = true; 
                else _hit = false;*/
            }
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
