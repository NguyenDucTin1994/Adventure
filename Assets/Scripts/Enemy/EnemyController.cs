using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolRoad;
    public int targetPoint;
    public Vector2 direction;

    public float timeForPatrolCritical;
    public float timeForPatrol;
    public float timeForIdleCritical;
    public float timeForIdle;
    public float speed;

    private EnemyLookingAtPlayer enemyLookingAtPlayer;
    private Animator animator;
    public bool isIdle { get; set; }
    public bool isFollowing { get; set; }
    public bool isPatrol { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        timeForIdle = timeForIdleCritical;
        timeForPatrol=timeForPatrolCritical;
        enemyLookingAtPlayer=gameObject.GetComponent<EnemyLookingAtPlayer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        animator.SetBool("isFollowing", enemyLookingAtPlayer.detectPlayer);
        
    }
    public void Flip()
    {
       direction = patrolRoad[targetPoint].position - transform.position;
        if (direction.x <= 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

    }
    
    
}
