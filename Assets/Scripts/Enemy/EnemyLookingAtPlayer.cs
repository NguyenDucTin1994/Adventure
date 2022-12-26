using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookingAtPlayer : MonoBehaviour
{
    public float maxDistance;
    public  bool detectPlayer;
    public LayerMask whatisPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastPlayer();
    }

    private void RaycastPlayer()
    {
        Vector2 origin=transform.position;
        Vector2 direction = transform.right * (-transform.localScale.x);
        Debug.DrawRay(origin, direction * maxDistance, Color.red);
        detectPlayer = Physics2D.Raycast(origin, direction, maxDistance, whatisPlayer);
        
    }
}
