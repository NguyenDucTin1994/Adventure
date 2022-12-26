using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdController : MonoBehaviour
{
    public Transform[] patrolRoad;
    public int targetPoint;
    public Vector2 direction;
    public float rot;

    public float timeForPatrolCritical;
    public float timeForPatrol;
    public float timeForIdleCritical;
    public float timeForIdle;
    public float speed;

    private Animator animator;
    public bool isIdle { get; set; }
    public bool isPatrol { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        timeForIdle = timeForIdleCritical;
        timeForPatrol = timeForPatrolCritical;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
    public void Flip()
    {
        direction = patrolRoad[targetPoint].position - transform.position;
        if (direction.x <= 0)
            transform.rotation = Quaternion.Euler(0,0,0);
        else
            transform.rotation = Quaternion.Euler(0, rot, 0);

    }
}
