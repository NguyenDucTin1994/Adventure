using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadController : MonoBehaviour
{
    private EnemyPatrol enemyPatrol;
    public Animator ani;
    public bool isMove;
    public float timeForIdle;
    public float timeForIdleCritical;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();
        speed = enemyPatrol.speed;
        ani= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var point in enemyPatrol.patrolRoad)
        {
            if (transform.position == point.position && timeForIdle>0)
            {
                timeForIdle -= Time.deltaTime;
                enemyPatrol.speed = 0;
            }
            if (transform.position == point.position && timeForIdle <= 0)
            {
                
                enemyPatrol.speed = speed;
                StartCoroutine("WaitForSecond");

            }

        }

        ani.SetFloat("speed", enemyPatrol.speed);
    }

    public IEnumerator WaitForSecond()
    {
        yield  return new WaitForSeconds(0.1f);
        timeForIdle = timeForIdleCritical;
    }
}
