using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBackGroundSingleton : MonoBehaviour
{
    public static SoundBackGroundSingleton instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
