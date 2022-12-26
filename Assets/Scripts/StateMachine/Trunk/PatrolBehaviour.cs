using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
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
        if (_trunkController.transform.position == _trunkController.patrolRoad[_trunkController.targetPoint].position)
            IncreaseTargetPoint();
        _trunkController.transform.position = Vector3.MoveTowards(_trunkController.transform.position, _trunkController.patrolRoad[_trunkController.targetPoint].position, _trunkController.speed * Time.deltaTime);
        _trunkController.timeForPatrol-=Time.deltaTime;
        if(_trunkController.timeForPatrol < 0)
        {

            _trunkController.timeForPatrol = _trunkController.timeForPatrolCritical;
            animator.SetBool("isPatrol", false);
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
    public void IncreaseTargetPoint()
    {
        _trunkController.targetPoint++;
        if (_trunkController.targetPoint >= _trunkController.patrolRoad.Length)
            _trunkController.targetPoint = 0;

    }
}
