using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PersonneMouvement : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
	private Vector3 rotation = Vector3.zero;
   
    // Use this for initialization
    void Start () 
    {
        rb = GetComponent<Rigidbody>();

	}
	
	public void Move (Vector3 _velocity) 
	{

        velocity = _velocity;
    }

	public void Rotation (Vector3 _rotation) 
	{

		rotation = _rotation;
	}

    void FixedUpdate()
    {
        PerformMovement();
		PerformRotation();

    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
    
	void PerformRotation()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
	}

}
