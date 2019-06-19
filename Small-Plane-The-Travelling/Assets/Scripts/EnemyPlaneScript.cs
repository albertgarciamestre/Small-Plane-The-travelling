using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneScript : MonoBehaviour {

    public GameObject player;


    /// Initialises current class

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

    }


    /// Called once per frame

    void Update()
    {
        if (transform.position.z < player.transform.position.z - 300)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    /// Called when rigid body enters the current object, deactivates current plane from scene

    /// <param name="other"></param>
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            gameObject.SetActive(false);
        }
       
    }
}
