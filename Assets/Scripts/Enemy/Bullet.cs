using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float lifeDuration;
    private float timer;
    private PlantController _plantController;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySound(4);
        _plantController=FindObjectOfType<PlantController>();
        timer = lifeDuration;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left*speed*_plantController.gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }

}
