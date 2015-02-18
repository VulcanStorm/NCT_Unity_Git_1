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
	
	public float walkSpeed = 20;
	public float strafeSpeed = 20;
	
	public float linearDrag = 0.66f;
	
	public Vector3 moveVel = Vector3.zero;
	public Vector3 inputVect = Vector3.zero;
	
	public float rigidVelMag;
	public Vector3 transPos;
	
	
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
		
	}
	
	void FixedUpdate () {
		// remove the added velocity last timestep
		rigidVelMag = thisRigidbody.velocity.magnitude;
		//thisRigidbody.velocity -=moveVel;
		//thisRigidbody.AddForce(-moveVel);
		// calculate new velocity vector to add
		
		
		
		// multiply the velocity by the drag vector
		thisRigidbody.velocity *= linearDrag;
		// check for a low velocity to stop moving
		
		// create a direction vector based on input
		inputVect = new Vector3(walkInput,0,strafeInput);
		inputVect = new Vector3(inputVect.x * strafeSpeed , 0 , inputVect.z * walkSpeed);
		inputVect.Normalize();
		
		
		// convert this vector from world space, to local space
		moveVel = thisTransform.TransformDirection(inputVect);
		
		// normalise the vector so it always has a length of 1
		moveVel = new Vector3(moveVel.x * strafeSpeed , 0 , moveVel.z * walkSpeed);
		
		//moveVel *= 50;
		
		// now multiply the direction vector by speeds
		//moveVel = new Vector3(moveVel.x * strafeSpeed , 0 , moveVel.z * walkSpeed);
		
		thisRigidbody.AddForce(moveVel, ForceMode.VelocityChange);
		// add this new velocity vector to the rigidbody
		//thisRigidbody.velocity += moveVel;
		
	}
}
