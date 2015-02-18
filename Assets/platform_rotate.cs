using UnityEngine;
using System.Collections;

public class platform_rotate : MonoBehaviour {

	Transform thisTransform;
	Rigidbody thisRigidbody;
	
	public int rotateSpeed = 30;
	public Quaternion rot;
	
	// Use this for initialization
	void Start () {
	thisRigidbody = this.rigidbody;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate () {
		rot = Quaternion.Euler(0,rotateSpeed * Time.deltaTime,0);
		thisRigidbody.MoveRotation(thisRigidbody.rotation  * rot);
	}
}
