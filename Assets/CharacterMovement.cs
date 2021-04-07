using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 inputDirection = Vector3.zero;
	
	void Start ()
    {
		
	}
	
	
	private void Update ()
    {
        inputDirection.x = Input.GetAxis("LeftJoystickHorizontal");
        inputDirection.y = Input.GetAxis("LeftJoystickVertical") * -1f;

        


        if (inputDirection.x < 0.1f && inputDirection.x > -0.1f)
        {
            inputDirection.x = 0f;
        }

        if (inputDirection.y < 0.1f && inputDirection.y > -0.1f)
        {
            inputDirection.y = 0f;
        }

        //inputDirection.x = Mathf.Round(inputDirection.x * 10f) / 10f;
        //inputDirection.y = Mathf.Round(inputDirection.y * 10f) / 10f;

        //Debug.Log(inputDirection.x);

    }

    private void FixedUpdate()
    {
        transform.position += inputDirection * 0.025f;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "room")
        {

            other.gameObject.GetComponentInChildren<Renderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "room")
        {
            
            other.gameObject.GetComponentInChildren<Renderer>().enabled = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "room")
        {
           
            other.gameObject.GetComponentInChildren<Renderer>().enabled = true;
        }
       
    }

    
}
