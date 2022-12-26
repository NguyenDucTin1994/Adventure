using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBirdBehaviour : StateMachineBehaviour
{
    private BlueBirdController _blueBird;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _blueBird = animator.gameObject.GetComponent<BlueBirdController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _blueBird.timeForIdle -= Time.deltaTime;
        if (_blueBird.timeForIdle < 0)
        {
            _blueBird.timeForIdle = _blueBird.timeForIdleCritical;
            animator.SetBool("isPatrol", true);
        }

    }
}
