using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushRunnerMovement : MonoBehaviour
{
  


    public float speed;

    //this might get messed up if i choose to spawn the player charaqcter in as opped to it starting in the scene by default
    public GameObject playerCharacter;

    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerCharacter.transform.position, speed * Time.deltaTime);

        
    }

  
}
