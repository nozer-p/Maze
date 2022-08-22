using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        //Time.timeScale = 0.3f;
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Win");
        }

        if (other.gameObject.tag == "DeadZone")
        {
            Destroy(this.gameObject);
            Debug.Log("Lose");
        }
    }
}