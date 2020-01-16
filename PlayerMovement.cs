using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Units per frame")]
    public float MoveRate;

    [Tooltip("Angles per frame")]
    public float turnRate;

    public float horizontalBound = 100;
    public float verticalBound = 15;
    
    public GameObject decoration;
    private Vector3 frameStep;
    private Vector3 totalOffset;

    // Use this for initialization
    void Start()
    {
        turnRate *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Change direction
        if(Input.GetKeyDown(KeyCode.Space))
        {
            turnRate *= -1;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            turnRate *= -1;
        }

        // Check level bounds
        if(transform.position.y > verticalBound)
            transform.position = new Vector3(transform.position.x, verticalBound, transform.position.z);
        else if(transform.position.y < -verticalBound)
            transform.position = new Vector3(transform.position.x, -verticalBound, transform.position.z);
        else
        {
            // Rotate ship, then move forward in the new direction
            transform.Rotate(Vector3.forward, turnRate, Space.Self);

            frameStep = transform.rotation * Vector3.up * MoveRate;
            frameStep.y = Mathf.Clamp(frameStep.y, -verticalBound, verticalBound);

            transform.position += frameStep;
            totalOffset += frameStep;

            // Background stuff
            decoration.transform.rotation = Quaternion.identity;
            decoration.transform.position =
                new Vector3(transform.position.x, transform.position.y) - (totalOffset * 0.1f);
        }
    }
}
