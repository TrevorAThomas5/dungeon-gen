using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0Spawner : MonoBehaviour
{
    public GameObject bushRunner;

    private int roomLayoutIndex = 0;
	
	void Start ()
    {
        roomLayoutIndex = Random.Range(0, 2);

        if(roomLayoutIndex == 0)
        {
            if(transform.rotation.z == 0f || transform.rotation.z == 180f)
            {
                Instantiate(bushRunner, new Vector3(transform.position.x + 1f, transform.position.y + 0.5f, 0), Quaternion.Euler(0, 0, 0));
                Instantiate(bushRunner, new Vector3(transform.position.x + 1f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 0));
                Instantiate(bushRunner, new Vector3(transform.position.x - 1f, transform.position.y + 0.5f, 0), Quaternion.Euler(0, 0, 0));
                Instantiate(bushRunner, new Vector3(transform.position.x - 1f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 0));
            }

            else
            {
                Instantiate(bushRunner, new Vector3(transform.position.x + .5f, transform.position.y + 1f, 0), Quaternion.Euler(0, 0, 0));
                Instantiate(bushRunner, new Vector3(transform.position.x + .5f, transform.position.y - 1f, 0), Quaternion.Euler(0, 0, 0));
                Instantiate(bushRunner, new Vector3(transform.position.x - .5f, transform.position.y + 1f, 0), Quaternion.Euler(0, 0, 0));
                Instantiate(bushRunner, new Vector3(transform.position.x - .5f, transform.position.y - 1f, 0), Quaternion.Euler(0, 0, 0));
            }
        }

        if(roomLayoutIndex == 1)
        {
            Debug.Log("blank room");
        }
	}
}
