using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolRoad;
    public float speed;
    public int targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolRoad[targetPoint].position)
            IncreaseTargetPoint();
        transform.position = Vector3.MoveTowards(transform.position, patrolRoad[targetPoint].position,speed*Time.deltaTime);
    }

    
    public void IncreaseTargetPoint()
    {
        targetPoint++;
        if(targetPoint>=patrolRoad.Length)
            targetPoint = 0;

    }
}
