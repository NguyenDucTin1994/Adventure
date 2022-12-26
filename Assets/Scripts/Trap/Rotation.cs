using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotZ;
    public float rotSpeed;
    public bool isClockwiseRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isClockwiseRotation)
        {
            rotZ -= Time.deltaTime * rotSpeed;
        }
        else
        {
            rotZ += Time.deltaTime * rotSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
