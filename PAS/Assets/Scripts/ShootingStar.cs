using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStar : MonoBehaviour {
	public float xSpeed, ySpeed, amplitude;
	private Vector3 currentPosition;
	void Start() {
		GameObject star = new GameObject ("ShootingStar");
		
		Instantiate (star);
	}
	void FixedUpdate() {
		currentPosition.x += xSpeed;
		currentPosition.y += Mathf.Sin (Time.realtimeSinceStartup * ySpeed) * amplitude;
		transform.position = currentPosition;
	}
}