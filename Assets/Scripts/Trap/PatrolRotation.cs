using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRotation : MonoBehaviour
{
    Vector3 currentEuler;
    public float rotSpeed;
    public float rotCritical1;
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotSpeed, rotCritical1)-rotCritical1/2);
    }
}
