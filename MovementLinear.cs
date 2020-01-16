using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLinear : MonoBehaviour
{
    [Tooltip("Units forward per frame")]
    public float MoveRate;
	
	void Update ()
    {
        transform.position += transform.rotation * Vector3.up * MoveRate;
    }
}
