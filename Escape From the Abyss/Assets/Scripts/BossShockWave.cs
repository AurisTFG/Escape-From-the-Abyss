using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShockWave : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//FindObjectOfType<BossMovement>().ActivateSpike();
		//FindObjectOfType<BossMovement>().ResetTime();
		animator.gameObject.GetComponent<BossMovement>().ActivateHorn();
		animator.gameObject.GetComponent<BossMovement>().explosion();
		animator.gameObject.GetComponent<BossMovement>().ResetTime();

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//animator.gameObject.GetComponent<BossMovement>().explosion();
		//animator.gameObject.GetComponent<BossMovement>().DeactivateHorn();
		//animator.gameObject.GetComponent<BossMovement>().flee();
	}

	// OnStateMove is called right after Animator.OnAnimatorMove()
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//	animator.gameObject.GetComponent<BossMovement>().DeactivateHorn();
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK()
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that sets up animation IK (inverse kinematics)
	//}
	//IEnumerator Boom(Animator animator)
	//{
	//	yield return new WaitForSeconds(1);

	//	animator.gameObject.GetComponent<BossMovement>().explosion();

	//}
}
