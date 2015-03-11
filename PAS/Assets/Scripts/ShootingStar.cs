using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStar : MonoBehaviour {
	public GameObject shootingStar;
	System.Random r = new System.Random();
	//public float randomScalar;
	public float lastForce;
	void Start() {
		//randomScalar = r.Next (10)/100;
		//shootingStar = Instantiate (shootingStar, transform.position, Quaternion.identity) as GameObject;
		//shootingStar.rigidbody2D.AddForce (Vector3.right * 400);
	}
	void Update() {
		//shootingStar.rigidbody2D.velocity = new Vector2 (1, 0).normalized*10;
		//float argument = Time.realtimeSinceStartup * 100;
		//shootingStar.rigidbody.AddForce(Vector3.up * (Mathf.Sin (argument) * 500 - (2*lastForce)));
		//lastForce = Mathf.Sin (argument) * 500;
	}
	public void starFactory() {
		GameObject shootingStar2 = Instantiate (shootingStar, transform.position, Quaternion.identity) as GameObject;
		shootingStar2.GetComponent<Rigidbody2D>().AddForce (Vector3.right * 500);
	}
	public Vector3 destroyStar() {
		Vector3 lastPos = new Vector3 ();
		foreach (GameObject shape in GameObject.FindGameObjectsWithTag("ShootingStar"))
		{
			lastPos = shape.transform.position;
			Debug.Log (shape);
			Object.Destroy(shape);
		}
		return lastPos;
	}
}