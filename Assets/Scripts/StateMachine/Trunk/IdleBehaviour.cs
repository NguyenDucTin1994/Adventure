using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    private EnemyController _trunkController;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _trunkController = animator.gameObject.GetComponent<EnemyController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _trunkController.timeForIdle -= Time.deltaTime;
        if (_trunkController.timeForIdle < 0)
        {
            _trunkController.timeForIdle = _trunkController.timeForIdleCritical;
            animator.SetBool("isPatrol", true);
        }
        
    }
}
