using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private EnemyPatrol enemyPatrol;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipFace();
    }
    public void FlipFace()
    {
        direction = enemyPatrol.patrolRoad[enemyPatrol. targetPoint].position - transform.position;
        if (direction.x <= 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

    }
}
