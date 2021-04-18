using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FighterState : StateMachineBehaviour
{

    public AnimationManager am;
    public float hf;
    public float vf;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(am == null)
        {
            am = animator.GetComponent<AnimationManager>();
        }
       
       am.rb.AddRelativeForce(new Vector3(0,vf,0));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("stateInfo: "+stateInfo);

            //Debug.Log("h: "+animator.GetFloat("horizontal"));

            float h = animator.GetFloat("horizontal");

            if(h > 0)
            {
            am.rb.AddRelativeForce(new Vector3(0,0,hf));
            }
            else if(h < 0)
            {
            am.rb.AddRelativeForce(new Vector3(0,0,-hf));
            }
            else
            {
            am.rb.AddRelativeForce(new Vector3(0,0,0));
            }
            //Debug.Log("hash: "+stateInfo(0).nameHash);

        //   if(stateInfo(0).nameHash == Animator.StringToHash("Base Layer.idle1"))
        //   {

        //   }
        //   else
        //   {

        //   }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
