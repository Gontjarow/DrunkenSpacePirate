using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{


	void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with " + collision.collider.name);
        if (collision.collider.name.Equals("Wormhole"))
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
