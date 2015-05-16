using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStar : MonoBehaviour {
	public GameObject shootingStar;
	public float lastForce;

	private double checkpointTime = 0;

    GameObject cloneStar;
	System.Random r = new System.Random();
	bool isUp = true;
    bool starAlive = false;

	void Update() {
		if(Time.time > checkpointTime && starAlive) {
			//Random movement simulation
			if(isUp)
				cloneStar.GetComponent<Rigidbody2D>().AddForce (Vector3.up * 300);
			else
				cloneStar.GetComponent<Rigidbody2D>().AddForce (Vector3.down * 375);
			isUp = !isUp;
			checkpointTime = checkpointTime + 1;
			Debug.Log(checkpointTime);
		}
	}
	public void starFactory() {
		cloneStar = Instantiate (shootingStar,new Vector3(-15,(float)(r.NextDouble () * 5 - 5),0), Quaternion.identity) as GameObject;
        starAlive = true;
		cloneStar.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "star";
		cloneStar.GetComponent<Rigidbody2D>().AddForce (Vector3.right * 400);
		cloneStar.GetComponent<Rigidbody2D>().AddForce (Vector3.up * 300);
	}
	public Vector3 destroyStar() {
		Vector3 lastPos = new Vector3 ();
		foreach (GameObject shape in GameObject.FindGameObjectsWithTag("ShootingStar"))
		{
			lastPos = shape.transform.position;
			Object.Destroy(shape);
            starAlive = false;
		}
		return lastPos;
	}
}