using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGSpin : MonoBehaviour
{
    [Tooltip("Angles per frame")]
    public float MaxSpeed;

    float speed;

    void Start()
    {
        speed = Random.Range(-MaxSpeed, MaxSpeed);
    }
    
    void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
