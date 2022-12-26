using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollection : MonoBehaviour
{
    public int point;
    public static int countFruitToAddHealth;
    public int numberOfFruitToAddHealth;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countFruitToAddHealth >= numberOfFruitToAddHealth)
        {
            HealthManager.IncreaseHealth();
            countFruitToAddHealth=0;
            StartCoroutine("PlaySoundDelay");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            countFruitToAddHealth++;
            SoundManager.PlaySound(0);
            ScoreManager.AddPoint(point);
            Destroy(gameObject);
        }
    }

    public IEnumerator PlaySoundDelay()
    {
        yield return new WaitForSeconds(delayTime);
        SoundManager.PlaySound(5);
            ;
    }

}
