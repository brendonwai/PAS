using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStar : MonoBehaviour {
	public float xSpeed, ySpeed, amplitude;
	public GameObject shootingStar;
	private Vector3 currentPosition;
	void Start() {
		//GameObject star = new GameObject ("ShootingStar");
		
		shootingStar = Instantiate (shootingStar, transform.position, Quaternion.identity) as GameObject;
		shootingStar.rigidbody.AddForce (Vector3.right * 400);
	}
	void Update() {
		shootingStar.rigidbody.AddForce(Vector3.up * Mathf.Sin (Time.realtimeSinceStartup*500) * 100);
	}
}