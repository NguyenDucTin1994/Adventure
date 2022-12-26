using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdPatrolBehaviour : StateMachineBehaviour
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
        if (_blueBird.transform.position == _blueBird.patrolRoad[_blueBird.targetPoint].position)
            IncreaseTargetPoint();
        _blueBird.transform.position = Vector3.MoveTowards(_blueBird.transform.position, _blueBird.patrolRoad[_blueBird.targetPoint].position, _blueBird.speed * Time.deltaTime);
        _blueBird.timeForPatrol -= Time.deltaTime;
        if (_blueBird.timeForPatrol < 0)
        {

            _blueBird.timeForPatrol = _blueBird.timeForPatrolCritical;
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
        _blueBird.targetPoint++;
        if (_blueBird.targetPoint >= _blueBird.patrolRoad.Length)
            _blueBird.targetPoint = 0;

    }
}

