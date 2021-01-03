using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{
    public class AnimationWaiter : MonoBehaviour
    {
        #region variables
        const string animBaseLayer = "Base Layer";
        #endregion

        #region methods


        public  IEnumerator waitToEnterInTheState(Animator targetAnim, string stateName, State state){
            //int animHash = 0;
            int hashStateName = Animator.StringToHash(animBaseLayer+"."+stateName);
            //targetAnim.CrossFadeInFixedTime(stateName, 0.6f);

            //Wait until we enter the current state
            while (targetAnim.GetCurrentAnimatorStateInfo(0).fullPathHash != hashStateName)
            {
                yield return null;
            }

            Debug.Log("["+stateName+"]"+" ENTER");
            state.Enter();
        }

        public IEnumerator waitTillTheAnimationEnds(Animator targetAnim, State state){
            float counter = 0;
            float waitTime = targetAnim.GetCurrentAnimatorStateInfo(0).length;
            Debug.Log("waittime = "+waitTime);
            string clipname = targetAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            //Now, Wait until the current state is done playing
            while (counter < (waitTime))
            {
                counter += Time.deltaTime;
                yield return null;
            }
            Debug.Log("["+clipname+"] Done Playing");
            state.ExecuteAfterAnimation();
        }


        public IEnumerator waitSomeSeconds(State state,float time){
            float counter = 0;
            while(counter < (time)){
                 counter += Time.deltaTime;
                yield return null;
            }
            state.ExecuteAfterAnimation();
        }



    }
    #endregion
}
