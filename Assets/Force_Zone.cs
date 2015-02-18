using UnityEngine;
using System.Collections;

public class Force_Zone : MonoBehaviour {
	
	public Vector3 forceDirection;
	public float speed = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay (Collider other) {
		other.rigidbody.AddForce(forceDirection * speed, ForceMode.Acceleration);
	}
}
