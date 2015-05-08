using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStar : MonoBehaviour {
	public GameObject shootingStar;
	System.Random r = new System.Random();
	public float lastForce;
	bool isUp = true;
	int counter = 0; //To simulate adding force every n number of seconds.

	void Start() {
	}

	void Update() {
		if (Time.time % .5 < .1)
			counter++;
		if(counter % 5 == 0) {
			//Random movement simulation
			if(isUp)
				shootingStar.GetComponent<Rigidbody2D>().AddForce (Vector3.up * 300);
			else
				shootingStar.GetComponent<Rigidbody2D>().AddForce (Vector3.down * 300);
			isUp = !isUp;
		}
	}
	public void starFactory() {
		shootingStar = Instantiate (shootingStar,new Vector3(-15,(float)(r.NextDouble () * 5 - 5),0), Quaternion.identity) as GameObject;
		shootingStar.GetComponent<Rigidbody2D>().AddForce (Vector3.right * 4000);
		shootingStar.GetComponent<Rigidbody2D>().AddForce (Vector3.up * 100);
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