using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlattform : MonoBehaviour
{
    public float _fallingDelay;
    public float _destroyDelay;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(_fallingDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, _destroyDelay);

    }
}
