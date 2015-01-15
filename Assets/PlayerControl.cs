using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	Transform thisTransform;
	Rigidbody thisRigidbody;
	
	
	float walkInput = 0;
	float strafeInput = 0;
	float rotInput = 0;
	
	float newWalkInput = 0;
	float newStrafeInput = 0;
	
	public int walkSpeed = 20;
	public int strafeSpeed = 20;
	
	Vector3 moveVel = Vector3.zero;
	Vector3 inputVect = Vector3.zero;
	
	
	
	// Use this for initialization
	void Start () {
	thisTransform = this.transform;
	thisRigidbody = this.rigidbody;
	}
	
	// Update is called once per frame
	void Update () {
		walkInput = Input.GetAxisRaw("Vertical");
		strafeInput = Input.GetAxisRaw ("Horizontal");
		rotInput = Input.GetAxisRaw("Vertical2");
		/*
		if(newWalkInput < walkInput){
			walkInput = 0;
		}
		*/
		
	}
	
	void FixedUpdate () {
		// remove the added velocity last timestep
		rigidbody.velocity -=moveVel;
		
		// calculate new velocity vector to add
		
		// create a direction vector based on input
		inputVect = new Vector3(strafeInput,0,walkInput);
		// normalise the vector so it always has a length of 1
		moveVel.Normalize();
		
		
		// convert this vector from world space, to local space
		moveVel = thisTransform.TransformDirection(inputVect);
		
		// now multiply the direction vector by speeds
		moveVel = new Vector3(moveVel.x * strafeSpeed , 0 , moveVel.z * walkSpeed);
		
		
		// add this new velocity vector to the rigidbody
		rigidbody.velocity += moveVel;
		
		transform.Rotate(Vector3.up * rotInput * 90 * Time.deltaTime,Space.Self);
	}
}
