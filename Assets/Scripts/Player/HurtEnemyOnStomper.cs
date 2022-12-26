using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnStomper : MonoBehaviour
{
    public int dameToGive;
    public float heightKnockPlayer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().GiveDamage(dameToGive);
            rb.velocity = new Vector2(rb.velocity.x, heightKnockPlayer);
            ScoreManager.AddPoint(2);
        }
    }
}
